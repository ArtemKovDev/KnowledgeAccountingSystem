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
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IOptionsSnapshot<JwtSettings> jwtSettings,
            IMapper mapper)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _userService.Register(_mapper.Map<RegisterModel, Register>(model));

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon(LogonModel model)
        {
            var user = await _userService.Logon(_mapper.Map<LogonModel, Logon>(model));

            if (user is null) return BadRequest();

            var roles = await _userService.GetRoles(user);

            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            await _userService.CreateRole(model.RoleName);
            return Ok();
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetRoles());
        }

        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(AssignUserToRoleModel model)
        {
            await _userService.AssignUserToRoles(_mapper.Map<AssignUserToRoleModel, AssignUserToRoles>(model));

            return Ok();
        }


        [Authorize]
        [HttpGet("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize]
        [HttpGet("getCurrentUserRoles")]
        public async Task<IEnumerable<string>> GetCurrentUserRoles()
        {
            return await _userService.GetUserRoles(User);
        }

        [Authorize]
        [HttpGet("getCurrentUserSkills")]
        public IEnumerable<SkillModel> GetCurrentUserSkills()
        {
            return _userService.GetUserSkills(User);
        }

        [Authorize]
        [HttpPost("addCurrentUserSkill")]
        public IActionResult AddCurrentUserSkill(SkillModel skillModel)
        {
            _userService.AddCurrentUserSkill(User, skillModel);
            return Ok(skillModel);
        }
    }
}
