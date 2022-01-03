using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.SkillCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "manager")]
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly ISkillCategoryService _service;
        private readonly IMapper _mapper;
        public SkillCategoriesController(ISkillCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> Post(CreateSkillCategoryModel skillCategory)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<CreateSkillCategoryModel, SkillCategoryModel>(skillCategory));
                return Ok(skillCategory);
            }
            return BadRequest(ModelState);
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
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(skillCategory);
                return Ok(skillCategory);
            }
            return BadRequest(ModelState);
        }
    }
}
