using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating roles data 
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Assign user to roles.
        /// </summary>
        /// <param name="userRoles">UserRoles model</param>
        /// <returns>A task that represents the asynchronous AssignUserToRoles operation and contains IdentityResult</returns>
        Task<IdentityResult> AssignUserToRoles(UserRoles userRoles);
        /// <summary>
        /// Remove User From Roles.
        /// </summary>
        /// <param name="userRoles">UserRoles model</param>
        /// <returns>A task that represents the asynchronous RemoveUserFromRoles operation and contains IdentityResult</returns>
        Task<IdentityResult> RemoveUserFromRoles(UserRoles userRoles);
        /// <summary>
        /// Create new role.
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>A task that represents the asynchronous CreateRole operation and contains IdentityResult</returns>
        Task<IdentityResult> CreateRole(string roleName);
        /// <summary>
        /// Delete role by name.
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>A task that represents the asynchronous DeleteRole operation and contains IdentityResult</returns>
        Task<IdentityResult> DeleteRole(string roleName);
        /// <summary>
        /// Retrieve user roles by UserModel.
        /// </summary>
        /// <param name="userModel">User model</param>
        /// <returns>Role collection</returns>
        Task<IEnumerable<string>> GetRoles(UserModel userModel);
        /// <summary>
        /// Retrieve all roles.
        /// </summary>
        /// <returns>IdentityRole collection</returns>
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
