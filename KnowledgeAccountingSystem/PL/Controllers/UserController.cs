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
using PL.ViewModels.Skills;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = "user,manager")]
        [HttpGet("getUserCredentials")]
        public IActionResult GetUserCredentials()
        {
            return Ok(_userService.GetCurrentUserCredentials(User));
        }

        [Authorize(Roles = "user, manager")]
        [HttpPut("updateUserCredentials")]
        public async Task<IActionResult> UpdateUserCredentials(UpdateUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateCurrentUserCredentials(User, _mapper.Map<UpdateUserModel, UserModel>(userModel));
                return Ok(userModel);
            }
            return BadRequest(ModelState);
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
        public IActionResult AddSkill(CreateUserSkillModel userSkillModel)
        {
            if(_userService.AddCurrentUserSkill(User, userSkillModel.SkillId, userSkillModel.KnowledgeLevelId))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "user")]
        [HttpDelete("deleteSkill")]
        public IActionResult DeleteSkill(CreateUserSkillModel userSkillModel)
        {
            if (_userService.DeleteCurrentUserSkill(User, userSkillModel.SkillId, userSkillModel.KnowledgeLevelId))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
