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
    ///<inheritdoc/>
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        /// <summary>
        /// Inject instances of the UserManager and Mapper
        /// </summary>
        public AccountService(UserManager<User> userManager, IMapper mapper)
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

        public async Task<UserModel> Logon(Logon logon)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == logon.Email);

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? _mapper.Map<User, UserModel>(user) : null;
        }
    }
}
