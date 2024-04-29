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
    public class SalesController : ControllerBase
    {
        private readonly IGenericRepository<Sale> _saleRepository;

        public SalesController(IGenericRepository<Sale> salgen)
        {
            _saleRepository = salgen;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAllAsync()
        {
            var sale = await _saleRepository.GetAllAsync();
            if (sale == null) return NotFound();
            return Ok(sale);
        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetSaleById")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            var sale = await _saleRepository.GetById(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }
        [HttpPost]
        public ActionResult<Sale> Create(Sale sale)
        {
            var newSale = _saleRepository.Create(sale);
            if (newSale == null) return BadRequest();
            return CreatedAtRoute("GetSaleById", new {id = newSale.Id }, newSale);
        }
        [HttpPut("{id}")]
        public ActionResult<Sale> Update(int id, Sale sale)
        {
            if (id != sale.Id) return BadRequest();
            _saleRepository.Update(id, sale);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Sale> Delete(int id)
        {
            _saleRepository.Delete(id);
            return NoContent();
        }
    }
}
