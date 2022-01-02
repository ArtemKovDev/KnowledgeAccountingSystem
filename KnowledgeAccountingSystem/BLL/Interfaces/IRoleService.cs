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
        Task AssignUserToRoles(UserRoles assignUserToRoles);
        Task RemoveUserFromRoles(UserRoles assignUserToRoles);
        Task CreateRole(string roleName);
        Task DeleteRole(string roleName);
        Task<IEnumerable<string>> GetRoles(User user);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
