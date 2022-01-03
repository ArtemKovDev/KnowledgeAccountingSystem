using BLL.Models.Account;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task Register(Register user);
        Task<User> Logon(Logon logon);
        IEnumerable<UserModel> GetUsers();
    }
}
