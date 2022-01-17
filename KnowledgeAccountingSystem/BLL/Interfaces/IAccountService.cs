using BLL.Models.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for user registration and logon
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Execute user registration
        /// </summary>
        /// <param name="user">Register model</param>
        /// <returns>A task that represents the asynchronous Register operation and contains IdentityResult</returns>
        Task<IdentityResult> Register(Register user);

        /// <summary>
        /// Execute user logon
        /// </summary>
        /// <param name="logon">Logon model</param>
        /// <returns>A task that represents the asynchronous Logon operation and contains User model</returns>
        Task<UserModel> Logon(Logon logon);
    }
}
