﻿using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [ModelStateActionFilter]
    [Authorize(Roles = "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSkillService _userService;

        public UserController(IUserSkillService userService)
        {
            _userService = userService;
        }

        [HttpGet("getSkills")]
        public IActionResult GetSkills()
        {
            return Ok(_userService.GetUserSkills(User.Identity.Name));
        }

        [HttpPost("addSkill")]
        public async Task<IActionResult> AddSkill(UserSkillModel userSkillModel)
        {
            try
            {
                await _userService.AddUserSkill(User.Identity.Name, userSkillModel);
                return Ok(userSkillModel);
            }
            catch (KASException ex)
            {
                return BadRequest(new ResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new ResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
        }

        [HttpDelete("deleteSkill")]
        public async Task<IActionResult> DeleteSkill(UserSkillModel userSkillModel)
        {
            await _userService.DeleteUserSkill(userSkillModel.Id);
            return Ok();
        }
    }
}
