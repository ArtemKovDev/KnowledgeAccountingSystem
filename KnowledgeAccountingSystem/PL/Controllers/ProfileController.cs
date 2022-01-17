﻿using BLL.Interfaces;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Authorize(Roles = "user,manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("getUserCredentials")]
        public IActionResult GetUserCredentials()
        {
            return Ok(_profileService.GetUserCredentials(User.Identity.Name));
        }

        [HttpPut("updateUserCredentials")]
        public async Task<IActionResult> UpdateUserCredentials(UserModel userModel)
        {
            await _profileService.UpdateUserCredentials(userModel);
            return Ok(userModel);
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _profileService.GetUserRoles(User.Identity.Name));
        }
    }
}
