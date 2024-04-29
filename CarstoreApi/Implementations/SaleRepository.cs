using CarstoreApi.Repositories;
using DominC.Model;
using Microsoft.EntityFrameworkCore;
using DominC11;
namespace CarstoreApi.Implementations
{
    public class SaleRepository : IGenericRepository<Sale>

    {
        private readonly APIContext _salcontext;
        public SaleRepository(APIContext db1)
        {
            _salcontext = db1;
        }
        public Sale Create(Sale obj)
        {
            if (obj == null) return null;
            var newSale = new Sale()
            {
                Name = obj.Name,
                Total = obj.Total,
                CarId = obj.CarId,
                CustomerId = obj.CustomerId,
              };
            _salcontext.Sales.Add(newSale);
            _salcontext.SaveChanges();
            
            return newSale; ;
        }

        public void Delete(int id)
        {
            var sale = _salcontext.Sales.FirstOrDefault(c => c.Id == id);
          
            if (sale != null)
            {
                _salcontext.Sales.Remove(sale);
                _salcontext.SaveChanges();
            }

        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            var sales = await _salcontext.Sales.ToListAsync();
            if (sales.Count == 0)
                return null;
            return sales;
        }

        public async Task<Sale> GetById(int id)
        {
            var sale = await _salcontext.Sales.FirstOrDefaultAsync(c => c.Id == id);

            if (sale != null)
            {
              return sale;
            }
            else
            {
              return null;
            }
        }

        public void Update(int id, Sale obj)
        {
            var sale = _salcontext.Sales.FirstOrDefault(c => c.Id == id);
            if (sale == null) return;
            sale.Total = obj.Total;
            sale.Name = obj.Name;
            sale.CarId = obj.CarId;
            sale.CustomerId = obj.CustomerId;
            
            _salcontext.SaveChanges();
        }
    }
}
    

