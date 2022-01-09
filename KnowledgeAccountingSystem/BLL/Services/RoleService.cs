using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AssignUserToRoles(UserRoles assignUserToRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == assignUserToRoles.Email);
            var roles = _roleManager.Roles.ToList().Where(r => assignUserToRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();
            
            if(roles.Count == 0)
            {
                throw new KASException(string.Join(';', "This user role does not exist"));
            }

            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> RemoveUserFromRoles(UserRoles removeUserFromRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == removeUserFromRoles.Email);
            var roles = _roleManager.Roles.ToList().Where(r => removeUserFromRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();

            if (roles.Count == 0)
            {
                throw new KASException(string.Join(';', "This user role does not exist"));
            }

            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            return result;
        }

        public async Task<IdentityResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                throw new KASException(string.Join(';', "This user role does not exist"));
            }
            var result = await _roleManager.DeleteAsync(role);

            return result;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRoles(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
    }
}
