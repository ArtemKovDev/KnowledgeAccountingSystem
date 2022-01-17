using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "manager")]
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly ISkillCategoryService _service;
        public SkillCategoriesController(ISkillCategoryService service)
        {
            _service = service;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public IEnumerable<SkillCategoryModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<SkillCategoryModel> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SkillCategoryModel skillCategory)
        {
            await _service.AddAsync(skillCategory);
            return Ok(skillCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SkillCategoryModel skillCategory)
        {
            await _service.UpdateAsync(skillCategory);
            return Ok(skillCategory);
        }
    }
}
