using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task Register(Register user);
        Task<Person> Logon(Logon logon);
        Task AssignUserToRoles(AssignUserToRoles assignUserToRoles);
        Task CreateRole(string roleName);
        Task<IEnumerable<string>> GetRoles(Person user);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
