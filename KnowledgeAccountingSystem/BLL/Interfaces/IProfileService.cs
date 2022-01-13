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
        UserModel GetUserCredentials(string userName);
        Task UpdateUserCredentials(string userName, UserModel userModel);
        Task<IEnumerable<string>> GetUserRoles(string userName);
    }
}
