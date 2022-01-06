using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Register(Register user)
        {
            var result = await _userManager.CreateAsync(new User
            {
                Email = user.Email,
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PlaceOfWork = user.PlaceOfWork,
                Education = user.Education
            }, user.Password);

            return result;
        }

        public async Task<User> Logon(Logon logon)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == logon.Email);

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? user : null;
        }

        public IEnumerable<UserModel> GetUsers(FilterSearch filterSearch)
        {
            var users = _userManager.Users;

            if (filterSearch != null)
            {
                if (filterSearch.Email != null && filterSearch.Email != "")
                {
                    users = users.Where(u => u.Email == filterSearch.Email);
                }

                if (filterSearch.FirstName != null && filterSearch.FirstName != "")
                {
                    users = users.Where(u => u.FirstName == filterSearch.FirstName);
                }

                if (filterSearch.LastName != null && filterSearch.LastName != "")
                {
                    users = users.Where(u => u.LastName == filterSearch.LastName);
                }

                if (filterSearch.PlaceOfWork != null && filterSearch.PlaceOfWork != "")
                {
                    users = users.Where(u => u.PlaceOfWork == filterSearch.PlaceOfWork);
                }

                if (filterSearch.Education != null && filterSearch.Education != "")
                {
                    users = users.Where(u => u.Education == filterSearch.Education);
                }
            }

            return _mapper.Map<List<User>, List<UserModel>>(users.ToList());
        }
    }
}
