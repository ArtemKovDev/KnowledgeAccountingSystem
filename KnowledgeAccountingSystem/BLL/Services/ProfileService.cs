using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using BLL.Validation;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    ///<inheritdoc/>
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        /// <summary>
        /// Inject instances of the UserManager and Mapper
        /// </summary>
        public ProfileService(UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public UserModel GetUserCredentials(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            if (user is null)
            {
                throw new KASException(string.Join(';', "User is not valid"));
            }

            return _mapper.Map<User, UserModel>(user);
        }

        public async Task UpdateUserCredentials(UserModel userModel)
        {
            if (userModel.Email == "" || userModel.FirstName == "" || userModel.LastName == "" || userModel.PlaceOfWork == "" || userModel.Education == "")
            {
                throw new KASException(string.Join(';', "Model is not valid"));
            }

            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userModel.Email);

            if (user is null)
            {
                throw new KASException(string.Join(';', "User is not valid"));
            }

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Education = userModel.Education;
            user.PlaceOfWork = userModel.PlaceOfWork;
            await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            if (user is null)
            {
                throw new KASException(string.Join(';', "User is not valid"));
            }

            return (await _userManager.GetRolesAsync(user)).ToList();
        }
    }
}
