﻿using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PL.Filters;
using PL.Helpers;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelStateActionFilter]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IRoleService roleService,
            IOptionsSnapshot<JwtSettings> jwtSettings,
            IMapper mapper)
        {
            _accountService = accountService;
            _roleService = roleService;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _accountService.Register(_mapper.Map<RegisterModel, Register>(model));

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon(LogonModel model)
        {
            var user = await _accountService.Logon(_mapper.Map<LogonModel, Logon>(model));

            if (user is null) return BadRequest();

            var roles = await _roleService.GetRoles(user);

            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserModel model)
        {
            await _accountService.DeleteUser(model.Email);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("getUsers")]
        public IEnumerable<UserModel> GetUsers()
        {
            return _accountService.GetUsers();
        }
    }
}
