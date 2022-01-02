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
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UserManager<Person> userManager,
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
            Person user = await _userManager.GetUserAsync(claimsPrincipal);
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public IEnumerable<SkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var skills = _unitOfWork.PersonSkillRepository.GetAllWithDetails().Where(ps => ps.PersonId == userId).Select(ps=>ps.Skill).ToList();

            return _mapper.Map<List<Skill>, List<SkillModel>>(skills);    
        }

        public bool AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            if (_unitOfWork.SkillRepository.FindAll().Select(s=>s.Id).Contains(skillId))
            {
                _unitOfWork.PersonSkillRepository.AddAsync(new PersonSkill { PersonId = userId, SkillId = skillId});
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        public bool DeleteCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);

            var ps = _unitOfWork.PersonSkillRepository.FindAll().FirstOrDefault(ps => ps.PersonId == userId && ps.SkillId == skillId);
            if (ps != null)
            { 
                _unitOfWork.PersonSkillRepository.Delete(ps);
                _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
