using BLL.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating User data 
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Retrieve information about user by user name.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User model</returns>
        UserModel GetUserCredentials(string userName);
        /// <summary>
        /// Update information about user.
        /// </summary>
        /// <param name="userModel">User model</param>
        /// <returns>A task that represents the asynchronous UpdateUserCredentials operation.</returns>
        Task UpdateUserCredentials(UserModel userModel);
        /// <summary>
        /// Get user roles by user name.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>Role collection</returns>
        Task<IEnumerable<string>> GetUserRoles(string userName);
    }
}
