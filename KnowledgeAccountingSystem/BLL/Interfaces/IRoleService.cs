using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> AssignUserToRoles(UserRoles assignUserToRoles);
        Task<IdentityResult> RemoveUserFromRoles(UserRoles assignUserToRoles);
        Task<IdentityResult> CreateRole(string roleName);
        Task<IdentityResult> DeleteRole(string roleName);
        Task<IEnumerable<string>> GetRoles(User user);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
