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
        IEnumerable<UserSkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal);
        Task AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, UserSkillModel userSkillModel);
        Task DeleteUserSkill(int userSkillId);
    }
}
