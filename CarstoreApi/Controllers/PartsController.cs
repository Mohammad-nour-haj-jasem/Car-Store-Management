using CarstoreApi.Implementations;
using CarstoreApi.Repositories;
using DominC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class PartsController : ControllerBase
    {
        private readonly IGenericRepository<Part> _partRepository;

        public PartsController(IGenericRepository<Part> partgen)
        {
            _partRepository = partgen;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetAllAsync()
        {
            var part = await _partRepository.GetAllAsync();
            if (part == null) return NotFound();
            return Ok(part);
        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPartById")]
        public async Task<ActionResult<Part>> GetPartById(int id)
        {
            var part = await _partRepository.GetById(id);
            if (part == null) return NotFound();
            return Ok(part);
        }
        [HttpPost]
        public ActionResult<Part> Create(Part part)
        {
            var newPart = _partRepository.Create(part);
            if (newPart == null) return BadRequest();
            return CreatedAtRoute("GetPartById", new { newPart.Id }, newPart);
        }
        [HttpPut("{id}")]
        public ActionResult<Part> Update(int id, Part part)
        {
            if (id != part.Id) return BadRequest();
            _partRepository.Update(id, part);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Part> Delete(int id)
        {
            _partRepository.Delete(id);
            return NoContent();
        }
    }
}
