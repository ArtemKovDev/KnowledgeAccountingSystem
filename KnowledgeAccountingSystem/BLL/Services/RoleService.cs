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
    ///<inheritdoc/>
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        /// <summary>
        /// Inject instances of the UserManager, RoleManager and Mapper 
        /// </summary>
        public RoleService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AssignUserToRoles(UserRoles userRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userRoles.Email);

            if(user is null)
            {
                throw new KASException(string.Join(';', "This user does not exist"));
            }

            var roles = _roleManager.Roles.ToList().Where(r => userRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();
            
            if(roles.Count == 0)
            {
                throw new KASException(string.Join(';', "This user role does not exist"));
            }

            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> RemoveUserFromRoles(UserRoles userRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userRoles.Email);

            if (user is null)
            {
                throw new KASException(string.Join(';', "This user does not exist"));
            }

            var roles = _roleManager.Roles.ToList().Where(r => userRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
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

        public async Task<IEnumerable<string>> GetRoles(UserModel userModel)
        {
            return (await _userManager.GetRolesAsync(_mapper.Map<UserModel, User>(userModel))).ToList();
        }
    }
}
