using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Account;
using BLL.Validation;
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

        public IEnumerable<UserSkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var userSkills = _unitOfWork.UserSkillRepository.GetAllWithDetails().Where(ps => ps.UserId == userId).ToList();

            return _mapper.Map<List<UserSkill>, List<UserSkillModel>>(userSkills);
        }

        public async Task AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, UserSkillModel userSkillModel)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);

            var userSkill = _unitOfWork.UserSkillRepository.FindAll().FirstOrDefault(u => u.SkillId == userSkillModel.SkillId && u.UserId == userId);
            if(userSkill != null)
            {
                throw new KASException("This skill already exists!");
            }

            await _unitOfWork.UserSkillRepository.AddAsync(new UserSkill { UserId = userId, SkillId = userSkillModel.SkillId, KnowledgeLevelId = userSkillModel.KnowledgeLevelId });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserSkill(int userSkillId)
        {
            await _unitOfWork.UserSkillRepository.DeleteByIdAsync(userSkillId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserSkill(ClaimsPrincipal claimsPrincipal, UserSkillModel userSkillModel)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var userSkill = _mapper.Map<UserSkillModel, UserSkill>(userSkillModel);
            userSkill.UserId = userId;

            var result = _unitOfWork.UserSkillRepository.FindAll().FirstOrDefault(u => u.SkillId == userSkillModel.SkillId && u.UserId == userId);
            if (result != null)
            {
                throw new KASException("This skill already exists!");
            }

            _unitOfWork.UserSkillRepository.Update(userSkill);
            await _unitOfWork.SaveAsync();
        }
    }
}
