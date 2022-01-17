using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    ///<inheritdoc/>
    public class SearchService : ISearchService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Inject instances of the UserManager, UnitOfWork and Mapper
        /// </summary>
        public SearchService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _userManager.Users;

            return _mapper.Map<List<User>, List<UserModel>>(users.ToList());
        }

        public IEnumerable<UserModel> GetUsersBySkill(int skillId)
        {
            var users = _unitOfWork.UserSkillRepository.GetAllWithDetails().Where(u => u.SkillId == skillId).Select(u => u.User).Distinct().ToList();
            return _mapper.Map<List<User>, List<UserModel>>(users);
        }

        public async Task<IEnumerable<UserModel>> GetUsersInRole(string roleName)
        {
            var users = _userManager.Users.ToList();
            var filteredUsers = new List<User>() { };
            foreach (var u in users)
            {
                var roles = (await _userManager.GetRolesAsync(u)).ToList();
                if (roles.Contains(roleName) || roles.Contains(roleName.ToUpper()))
                {
                    filteredUsers.Add(u);
                }
            }
            return _mapper.Map<List<User>, List<UserModel>>(filteredUsers);
        }
    }
}
