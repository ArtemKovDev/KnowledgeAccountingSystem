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
