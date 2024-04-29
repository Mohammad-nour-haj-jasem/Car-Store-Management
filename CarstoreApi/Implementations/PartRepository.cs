using CarstoreApi.Repositories;
using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;

namespace CarstoreApi.Implementations
{
    public class PartRepository : IGenericRepository<Part>
    {
        private readonly APIContext _partcontext;
        public PartRepository(APIContext db2)
        {
            _partcontext = db2;
        }
        public Part Create(Part obj)
        {
            if (obj == null) return null;
            var newPart = new Part()
            {
                Price = obj.Price,
                Quantity = obj.Quantity,
                supplier = obj.supplier,
                SupplierId = obj.SupplierId,
                Name = obj.Name,
                Cars = obj.Cars, 
            };

            _partcontext.Parts.Add(newPart);
            _partcontext.SaveChanges();

            return newPart;
        }

        public void Delete(int id)
        {

            var part = _partcontext.Parts.FirstOrDefault(c => c.Id == id);

            if (part != null)
            {
                _partcontext.Parts.Remove(part);
                _partcontext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Part>> GetAllAsync()
        {
            var parts = await _partcontext.Parts.ToListAsync();
            if (parts.Count == 0)
                return null;
            return parts;
        }

        public async Task<Part> GetById(int id)
        {
            var part = await _partcontext.Parts.FirstOrDefaultAsync(c => c.Id == id);
            if (part != null)
            {
                return part;
            }
            else
            {
                return null;
            }
        }

        public void Update(int id, Part obj)
        {
            var part = _partcontext.Parts.FirstOrDefault(c => c.Id == id);
            if (part == null) return;
            part.Cars = obj.Cars;
            part.supplier = obj.supplier;
            part.Price = obj.Price;
            part.Quantity = obj.Quantity;

            _partcontext.SaveChanges();
        }
    }
}
