using BLL.Interfaces;
using BLL.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Authorize(Roles = "manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("getUsers")]
        public IEnumerable<UserModel> GetUsers()
        {
            return _searchService.GetUsers();
        }

        [HttpGet("getUsers/skill/{id}")]
        public IEnumerable<UserModel> GetUsersBySkill(int id)
        {
            return _searchService.GetUsersBySkill(id);
        }

        [HttpPost("getUsers/role")]
        public async Task<IEnumerable<UserModel>> GetUsersInRole(RoleModel model)
        {
            return await _searchService.GetUsersInRole(model.Name);
        }
    }
}
