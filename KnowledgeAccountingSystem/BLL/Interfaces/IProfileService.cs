using BLL.Models.Account;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProfileService
    {
        UserModel GetCurrentUserCredentials(ClaimsPrincipal claimsPrincipal);
        Task UpdateCurrentUserCredentials(ClaimsPrincipal claimsPrincipal, UserModel userModel);
        Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal);
    }
}
