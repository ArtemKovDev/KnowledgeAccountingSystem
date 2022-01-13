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

        public IEnumerable<UserSkillModel> GetUserSkills(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            if (user is null)
            {
                throw new KASException(string.Join(';', "User is not valid"));
            }

            var userSkills = _unitOfWork.UserSkillRepository.GetAllWithDetails().Where(ps => ps.UserId == user.Id).ToList();

            return _mapper.Map<List<UserSkill>, List<UserSkillModel>>(userSkills);
        }

        public async Task AddCurrentUserSkill(string userName, UserSkillModel userSkillModel)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            if (user is null)
            {
                throw new KASException(string.Join(';', "User is not valid"));
            }

            var userSkill = _unitOfWork.UserSkillRepository.FindAll().FirstOrDefault(u => u.SkillId == userSkillModel.SkillId && u.UserId == user.Id);

            if(userSkill != null)
            {
                throw new KASException(string.Join(';', "This skill already exists!"));
            }

            await _unitOfWork.UserSkillRepository.AddAsync(new UserSkill { UserId = user.Id, SkillId = userSkillModel.SkillId, KnowledgeLevelId = userSkillModel.KnowledgeLevelId });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserSkill(int userSkillId)
        {
            await _unitOfWork.UserSkillRepository.DeleteByIdAsync(userSkillId);
            await _unitOfWork.SaveAsync();
        }
    }
}
