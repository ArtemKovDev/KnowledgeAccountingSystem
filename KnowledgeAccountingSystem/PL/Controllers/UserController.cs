using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetUserRoles(User));
        }

        [HttpGet("getSkills")]
        public IActionResult GetSkills()
        {
            return Ok(_userService.GetUserSkills(User));
        }

        [HttpPost("addSkill")]
        public IActionResult AddSkill(int Id)
        {
            if(_userService.AddCurrentUserSkill(User, Id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("deleteSkill")]
        public IActionResult DeleteSkill(int Id)
        {
            if (_userService.DeleteCurrentUserSkill(User, Id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
