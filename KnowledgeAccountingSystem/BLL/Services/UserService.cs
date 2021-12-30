using BLL.Interfaces;
using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<Person> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
    }
}
