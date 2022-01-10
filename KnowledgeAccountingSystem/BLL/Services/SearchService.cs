using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public SearchService(UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _userManager.Users;

            return _mapper.Map<List<User>, List<UserModel>>(users.ToList());
        }
    }
}
