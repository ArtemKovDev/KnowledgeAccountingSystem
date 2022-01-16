using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating User Skill data 
    /// </summary>
    public interface IUserSkillService
    {
        /// <summary>
        /// Retrieves all UserSkillModels
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>UserSkillModel collection</returns>
        IEnumerable<UserSkillModel> GetUserSkills(string userName);
        /// <summary>
        /// Add new UserSkillModel
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="userSkillModel">UserSkillModel</param>
        /// <returns>A task that represents the asynchronous AddUserSkill operation.</returns>
        Task AddUserSkill(string userName, UserSkillModel userSkillModel);
        /// <summary>
        /// Delete UserSkillModel
        /// </summary>
        /// <param name="userSkillId">UserSkill Id</param>
        /// <returns>A task that represents the asynchronous DeleteUserSkill operation.</returns>
        Task DeleteUserSkill(int userSkillId);
    }
}
