using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PL.Helpers;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getSkills")]
        public IActionResult GetSkills()
        {
            return Ok(_userService.GetUserSkills(User));
        }

        [HttpPost("addSkill")]
        public async Task<IActionResult> AddSkill(UserSkillModel userSkillModel)
        {
            await _userService.AddCurrentUserSkill(User, userSkillModel.SkillId, userSkillModel.KnowledgeLevelId);
            return Ok(userSkillModel);
        }

        [HttpDelete("deleteSkill")]
        public async Task<IActionResult> DeleteSkill(UserSkillModel userSkillModel)
        {
            await _userService.DeleteUserSkill(userSkillModel.Id);
            return Ok();
        }

        [HttpPut("updateSkill")]
        public async Task<IActionResult> UpdateSkill(UserSkillModel userSkillModel)
        {
            await _userService.UpdateUserSkill(User, userSkillModel);
            return Ok();
        }
    }
}
