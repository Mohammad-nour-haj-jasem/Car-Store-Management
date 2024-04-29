using CarstoreApi.Repositories;
using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;

namespace CarstoreApi.Implementations
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly APIContext _customercontext;
        public CustomerRepository(APIContext db4)
        {
            _customercontext = db4;
        }
        public Customer Create(Customer obj)
        {
            if (obj == null) return null;
            var newCustomer = new Customer()
            {
                Address = obj.Address,
                Age = obj.Age,
                Name = obj.Name,
            };

            _customercontext.Customers.Add(newCustomer);
            _customercontext.SaveChanges();

            return newCustomer;
        }

        public void Delete(int id)
        {
            var cust = _customercontext.Customers.FirstOrDefault(c => c.Id == id);

            if (cust != null)
            {
                _customercontext.Customers.Remove(cust);
                _customercontext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _customercontext.Customers.ToListAsync();
            if (customers.Count == 0)
                return null;
            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _customercontext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
               return null;
            }
        }

        public void Update(int id, Customer obj)
        {
            var customer = _customercontext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return;
         
            _customercontext.SaveChanges();
        }
    }
}
