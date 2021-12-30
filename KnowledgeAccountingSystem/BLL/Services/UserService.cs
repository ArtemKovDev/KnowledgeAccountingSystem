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

        public async Task Register(Register user)
        {
            var result = await _userManager.CreateAsync(new Person
            {
                Email = user.Email,
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PlaceOfWork = user.PlaceOfWork,
                Education = user.Education
            }, user.Password);

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
        }

        public async Task<Person> Logon(Logon logon)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == logon.Email);
            if (user is null) throw new System.Exception($"User not found: '{logon.Email}'.");

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? user : null;
        }

        public async Task AssignUserToRoles(AssignUserToRoles assignUserToRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == assignUserToRoles.Email);
            var roles = _roleManager.Roles.ToList().Where(r => assignUserToRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();

            var result = await _userManager.AddToRolesAsync(user, roles); // THROWS

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
        }

        public async Task CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new System.Exception($"Role could not be created: {roleName}.");
            }
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRoles(Person user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
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

        public void AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, SkillModel skillModel)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var skill = _mapper.Map<SkillModel, Skill>(skillModel);
            if (_unitOfWork.SkillRepository.FindAll().Select(s=>s.Id).Contains(skill.Id))
            {
                _unitOfWork.PersonSkillRepository.AddAsync(new PersonSkill { PersonId = userId, SkillId = skill.Id});
                _unitOfWork.SaveAsync();
            }
        }
    }
}
