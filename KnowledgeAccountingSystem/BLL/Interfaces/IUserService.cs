using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
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
        Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal);
        IEnumerable<SkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal);
        void AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, SkillModel skillModel);
    }
}
