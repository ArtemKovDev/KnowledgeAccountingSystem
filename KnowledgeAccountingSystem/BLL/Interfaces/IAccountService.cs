using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(Register user);
        Task<User> Logon(Logon logon);
        IEnumerable<UserModel> GetUsers();
    }
}
