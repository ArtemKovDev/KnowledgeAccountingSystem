using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ProfileService(UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public UserModel GetCurrentUserCredentials(ClaimsPrincipal claimsPrincipal)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == claimsPrincipal.Identity.Name);
            return _mapper.Map<User, UserModel>(user);
        }

        public async Task UpdateCurrentUserCredentials(ClaimsPrincipal claimsPrincipal, UserModel userModel)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == claimsPrincipal.Identity.Name);

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Education = userModel.Education;
            user.PlaceOfWork = userModel.PlaceOfWork;
            await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<string>> GetUserRoles(ClaimsPrincipal claimsPrincipal)
        {
            User user = await _userManager.GetUserAsync(claimsPrincipal);
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
    }
}
