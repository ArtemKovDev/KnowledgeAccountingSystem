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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal)
        {
            User user = await _userManager.GetUserAsync(claimsPrincipal);
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public IEnumerable<SkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var skills = _unitOfWork.UserSkillRepository.GetAllWithDetails().Where(ps => ps.UserId == userId).Select(ps=>ps.Skill).ToList();

            return _mapper.Map<List<Skill>, List<SkillModel>>(skills);    
        }

        public bool AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            if (_unitOfWork.SkillRepository.FindAll().Select(s=>s.Id).Contains(skillId))
            {
                _unitOfWork.UserSkillRepository.AddAsync(new UserSkill { UserId = userId, SkillId = skillId});
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        public bool DeleteCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);

            var ps = _unitOfWork.UserSkillRepository.FindAll().FirstOrDefault(ps => ps.UserId == userId && ps.SkillId == skillId);
            if (ps != null)
            { 
                _unitOfWork.UserSkillRepository.Delete(ps);
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
