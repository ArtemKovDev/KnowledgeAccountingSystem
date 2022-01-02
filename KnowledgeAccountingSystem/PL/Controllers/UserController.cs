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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "user,manager")]
        [HttpGet("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "user,manager")]
        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetUserRoles(User));
        }

        [Authorize(Roles = "user")]
        [HttpGet("getSkills")]
        public IActionResult GetSkills()
        {
            return Ok(_userService.GetUserSkills(User));
        }

        [Authorize(Roles = "user")]
        [HttpPost("addSkill")]
        public IActionResult AddSkill(int Id)
        {
            if(_userService.AddCurrentUserSkill(User, Id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "user")]
        [HttpDelete("deleteSkill")]
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
