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
    public class CustomersController : ControllerBase

    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public CustomersController(IGenericRepository<Customer> custgen)
        {
            _customerRepository = custgen;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllAsync()
        {
            var cust = await _customerRepository.GetAllAsync();
            if (cust == null) return NotFound();
            return Ok(cust);
        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var cust = await _customerRepository.GetById(id);
            if (cust == null) return NotFound();
            return Ok(cust);
        }
        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            var newCustomer = _customerRepository.Create(customer);
            if (newCustomer == null) return BadRequest();
            return CreatedAtRoute("GetCustomerById", new { newCustomer.Id }, newCustomer);
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> Update(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            _customerRepository.Update(id, customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            _customerRepository.Delete(id);
            return NoContent();
        }
    }
}
