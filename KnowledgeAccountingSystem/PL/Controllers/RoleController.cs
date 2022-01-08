using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(
            IRoleService roleService,
            IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            await _roleService.CreateRole(model.Name);
            return Ok();
        }

        [HttpDelete("deleteRole")]
        public async Task<IActionResult> DeleteRole(RoleModel model)
        {
            await _roleService.DeleteRole(model.Name);
            return Ok();
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles() as List<IdentityRole>;
            return Ok(_mapper.Map<List<IdentityRole>, List<RoleModel>>(roles));
        }

        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(UserRolesModel model)
        {
            await _roleService.AssignUserToRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

            return Ok();
        }

        [HttpDelete("removeUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(UserRolesModel model)
        {
            await _roleService.RemoveUserFromRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

            return Ok();
        }
    }
}
