using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
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
    public class KnowledgeLevelsController : ControllerBase
    {
        private readonly IKnowledgeLevelService _service;
        private readonly IMapper _mapper;
        public KnowledgeLevelsController(IKnowledgeLevelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public IEnumerable<KnowledgeLevelModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<KnowledgeLevelModel> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(KnowledgeLevelModel knowledgeLevel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(knowledgeLevel);
                return Ok(knowledgeLevel);
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
        public async Task<IActionResult> Put(KnowledgeLevelModel knowledgeLevel)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(knowledgeLevel);
                return Ok(knowledgeLevel);
            }
            return BadRequest(ModelState);
        }
    }
}
