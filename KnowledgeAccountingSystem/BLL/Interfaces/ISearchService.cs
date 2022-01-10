using BLL.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<UserModel> GetUsers();
        IEnumerable<UserModel> GetUsersBySkill(int skillId);
        Task<IEnumerable<UserModel>> GetUsersInRole(string roleName);
    }
}
