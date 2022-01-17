using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Account;
using BLL.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [ModelStateActionFilter]
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
            try
            {
                var result = await _roleService.CreateRole(model.Name);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new ResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
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

        [HttpDelete("deleteRole")]
        public async Task<IActionResult> DeleteRole(RoleModel model)
        {
            try
            {
                var result = await _roleService.DeleteRole(model.Name);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new ResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
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

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles() as List<IdentityRole>;
            return Ok(_mapper.Map<List<IdentityRole>, List<RoleModel>>(roles));
        }

        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(UserRolesModel model)
        {
            try
            {
                var result = await _roleService.AssignUserToRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new ResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
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

        [HttpDelete("removeUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(UserRolesModel model)
        {
            try
            {
                var result = await _roleService.RemoveUserFromRoles(_mapper.Map<UserRolesModel, UserRoles>(model));

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);

                    return BadRequest(new ResponseModel { Errors = errors, IsSuccessful = false });
                }
                return Ok();
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
    }
}
