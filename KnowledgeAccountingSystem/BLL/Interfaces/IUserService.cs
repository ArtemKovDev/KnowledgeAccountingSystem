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
        UserModel GetCurrentUserCredentials(ClaimsPrincipal claimsPrincipal);
        Task UpdateCurrentUserCredentials(ClaimsPrincipal claimsPrincipal, UserModel userModel);
        Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal);
        IEnumerable<SkillModel> GetUserSkills(ClaimsPrincipal claimsPrincipal);
        bool AddCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId, int knowledgeLevelId);
        bool DeleteCurrentUserSkill(ClaimsPrincipal claimsPrincipal, int skillId, int knowledgeLevelId);
    }
}
