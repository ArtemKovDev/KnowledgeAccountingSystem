using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeLevelsController : ControllerBase
    {
        private readonly IKnowledgeLevelService _service;
        public KnowledgeLevelsController(IKnowledgeLevelService service)
        {
            _service = service;
        }

        // GET: api/<SkillsController>
        [Authorize(Roles = "manager, user")]
        [HttpGet]
        public IEnumerable<KnowledgeLevelModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/<SkillsController>/5
        [Authorize(Roles = "manager")]
        [HttpGet("{id}")]
        public async Task<KnowledgeLevelModel> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [Authorize(Roles = "manager")]
        [HttpPost]
        public async Task<IActionResult> Post(KnowledgeLevelModel knowledgeLevel)
        {
            await _service.AddAsync(knowledgeLevel);
            return Ok(knowledgeLevel);
        }

        [Authorize(Roles = "manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "manager")]
        [HttpPut]
        public async Task<IActionResult> Put(KnowledgeLevelModel knowledgeLevel)
        {
            await _service.UpdateAsync(knowledgeLevel);
            return Ok(knowledgeLevel);
        }
    }
}
