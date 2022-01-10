using BLL.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<UserModel> GetUsers();
    }
}
