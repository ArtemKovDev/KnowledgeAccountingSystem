﻿using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public SearchController(
            ISearchService searchService,
            IRoleService roleService,
            IMapper mapper)
        {
            _searchService = searchService;
            _roleService = roleService;
            _mapper = mapper;
        }
        [Authorize(Roles = "manager")]
        [HttpGet("getUsers")]
        public IEnumerable<UserModel> GetUsers()
        {
            return _searchService.GetUsers();
        }
    }
}
