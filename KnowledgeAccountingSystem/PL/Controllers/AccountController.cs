using AutoMapper;
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
            var result = await _accountService.Register(_mapper.Map<RegisterModel, Register>(model));

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseModel { Errors = errors, IsSuccessfulRegistration = false });
            }

            await _roleService.AssignUserToRoles(_mapper.Map<UserRolesModel, UserRoles>(new UserRolesModel { Email = model.Email, Roles = new string[]{ "user" } }));

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon(LogonModel model)
        {
            var user = await _accountService.Logon(_mapper.Map<LogonModel, Logon>(model));

            if (user is null) return Unauthorized(new AuthResponseModel { ErrorMessage = "Invalid Authentication" });

            var roles = await _roleService.GetRoles(user);

            var token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            return Ok(new AuthResponseModel { IsAuthSuccessful = true, Token = token });
        }
    }
}
