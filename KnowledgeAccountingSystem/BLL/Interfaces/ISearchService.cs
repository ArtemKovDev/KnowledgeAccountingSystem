using BLL.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for selecting users by different criterias
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <returns>UserModel collection</returns>
        IEnumerable<UserModel> GetUsers();
        /// <summary>
        /// Retrieve users by skill id.
        /// </summary>
        /// <param name="skillId">Skill id</param>
        /// <returns>UserModel collection</returns>
        IEnumerable<UserModel> GetUsersBySkill(int skillId);
        /// <summary>
        /// Retrieve users by role.
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>UserModel collection</returns>
        Task<IEnumerable<UserModel>> GetUsersInRole(string roleName);
    }
}
