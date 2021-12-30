using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;
        private readonly IMapper _mapper;
        public SkillsController(ISkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public IEnumerable<SkillModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<SkillModel> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSkillModel skill)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<CreateSkillModel, SkillModel>(skill));
                return Ok(skill);
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
        public async Task<IActionResult> Put(SkillModel skill)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(skill);
                return Ok(skill);
            }
            return BadRequest(ModelState);
        }
    }
}
