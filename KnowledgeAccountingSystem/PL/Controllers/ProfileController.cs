using AutoMapper;
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
    [Authorize(Roles = "user,manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfileController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet("getUserCredentials")]
        public IActionResult GetUserCredentials()
        {
            return Ok(_profileService.GetCurrentUserCredentials(User));
        }

        [HttpPut("updateUserCredentials")]
        public async Task<IActionResult> UpdateUserCredentials(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _profileService.UpdateCurrentUserCredentials(User, userModel);
                return Ok(userModel);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _profileService.GetUserRoles(User));
        }
    }
}
