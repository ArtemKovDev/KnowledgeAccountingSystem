using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using BLL.Validation;
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
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _roleService.CreateRole(model.Name);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new RoleResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
            }
            catch(KASException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
        }

        [HttpDelete("deleteRole")]
        public async Task<IActionResult> DeleteRole(RoleModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _roleService.DeleteRole(model.Name);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new RoleResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
            }
            catch (KASException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }

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
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _roleService.AssignUserToRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new RoleResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
            }
            catch (KASException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
        }

        [HttpDelete("removeUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(UserRolesModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _roleService.RemoveUserFromRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new RoleResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
            }
            catch (KASException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new RoleResponseModel { Errors = new List<string>() { ex.Message }, IsSuccessful = false });
            }
        }
    }
}
