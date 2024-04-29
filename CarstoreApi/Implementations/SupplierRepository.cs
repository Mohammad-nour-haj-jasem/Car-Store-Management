using CarstoreApi.Repositories;
using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;

namespace CarstoreApi.Implementations
{
    public class SupplierRepository : IGenericRepository<Supplier>
    {
        private readonly APIContext _suppliercontext;
        public SupplierRepository(APIContext db3)
        {
            _suppliercontext = db3;
        }
        public Supplier Create(Supplier obj)
        {
            if (obj == null) return null;
            var newSupplier = new Supplier()
            {
                Address = obj.Address,
                Name = obj.Name,
                Parts= obj.Parts,
             };

            _suppliercontext.Suppliers.Add(newSupplier);
            _suppliercontext.SaveChanges();

            return newSupplier;
        }

        public void Delete(int id)
        {

            var supplier = _suppliercontext.Suppliers.FirstOrDefault(c => c.Id == id);

            if (supplier != null)
            {
                _suppliercontext.Suppliers.Remove(supplier);
                _suppliercontext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            var suppliers = await _suppliercontext.Suppliers.ToListAsync();
            if (suppliers.Count == 0)
                return null;
            return suppliers;
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _suppliercontext.Suppliers.FirstOrDefaultAsync(c => c.Id == id);
            if (supplier != null)
            {
                return supplier;
            }
            else
            {
                return null;
            }

        }

        public void Update(int id, Supplier obj)
        {
            var supplier = _suppliercontext.Suppliers.FirstOrDefault(c => c.Id == id);
            if (supplier == null) return;
            supplier.Name = obj.Name;
            supplier.Address = obj.Address;
            supplier.Parts = obj.Parts;

            _suppliercontext.SaveChanges();
        }
    }
}
