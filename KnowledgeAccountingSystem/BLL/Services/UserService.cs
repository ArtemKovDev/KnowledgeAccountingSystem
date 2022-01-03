using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Services
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal)
        {
            User user = await _userManager.GetUserAsync(claimsPrincipal);
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public IEnumerable<UserSkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var userSkills = _unitOfWork.UserSkillRepository.GetAllWithDetails().Where(ps => ps.UserId == userId).ToList();

            foreach(var u in userSkills)
            {
                yield return new UserSkillModel()
                {
                    SkillId = u.Skill.Id,
                    SkillName = u.Skill.Name,
                    SkillDescription = u.Skill.Description,
                    KnowledgeLevelId = u.KnowledgeLevel.Id,
                    KnowledgeLevel = u.KnowledgeLevel.Name
                };
            }    
        }

        public bool AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId, int knowledgeLevelId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            if (_unitOfWork.SkillRepository.FindAll().Select(s=>s.Id).Contains(skillId))
            {
                _unitOfWork.UserSkillRepository.AddAsync(new UserSkill { UserId = userId, SkillId = skillId, KnowledgeLevelId = knowledgeLevelId });
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        public bool DeleteCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId, int knowledgeLevelId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);

            var ps = _unitOfWork.UserSkillRepository.FindAll().FirstOrDefault(ps => ps.UserId == userId && ps.SkillId == skillId && ps.KnowledgeLevelId == knowledgeLevelId);
            if (ps != null)
            { 
                _unitOfWork.UserSkillRepository.Delete(ps);
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        public UserModel GetCurrentUserCredentials(ClaimsPrincipal claimsPrincipal)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == claimsPrincipal.Identity.Name);
            return _mapper.Map<User, UserModel>(user);
        }

        public async Task UpdateCurrentUserCredentials(ClaimsPrincipal claimsPrincipal, UserModel userModel)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == claimsPrincipal.Identity.Name);

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Education = userModel.Education;
            user.PlaceOfWork = userModel.PlaceOfWork;
            await _userManager.UpdateAsync(user);
        }
    }
}
