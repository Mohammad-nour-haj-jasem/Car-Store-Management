using CarstoreApi.Repositories;
using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;

namespace CarstoreApi.Implementations

{
    public class CarRepository : IGenericRepository<Car>

    {
        private readonly APIContext _context;
        public CarRepository(APIContext db)
        {
            _context = db;
        }
        //انشاء سجل سيارة جديد 
        public Car Create(Car obj)
        {
            //التحقق من ان الكائن المرسل غير فارغ
            if(obj == null) return null;
            //انشاء سجل للسيارة مع كامل بياناته
            var newCar = new Car()
            {
                Model = obj.Model,
                Gear = obj.Gear,
                Km = obj.Km,
                Year = obj.Year,
                Name = obj.Name
            };
            // إضافة السجل الجديد إلى قاعدة البيانات وحفظ التغييرات
            _context.Cars.Add(newCar);
               _context.SaveChanges();
            //ارجاع السجل الجديد 
            return newCar;
        }
        //  حذف سجل سيارة بناءً على المعرف الخاص(id)
                public void Delete(int id)
        {
            //البحث عن السجل الذي يحمل المعرف المطلوب

            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            // التحقق من وجود السجل وحذفه
            if (car != null)
                {
                    _context.Cars.Remove(car);
                    _context.SaveChanges();
                }
      
        }

        // الحصول على سجل سيارة بناءً على المعرف
        public async Task<Car> GetById(int id)
        {
            // البحث عن السجل بناءً على المعرف باستخدام البيانات الخاصة بقاعدة البيانات
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
           if (car != null)
                {
                // إرجاع السجل إذا وجد، وإلا إرجاع قيمة فارغة
                return car;                
                }
                else
                {
                 return null;
                }
        }
        // الحصول على جميع سجلات السيارات
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars.ToListAsync();
            if (cars.Count == 0)
                return null;
            return cars;
        }
        // تحديث بيانات السجل السيارة بناءً على المعرف
        public void Update(int id, Car obj)
        {
            // البحث عن السجل بناءً على المعرف
             var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            // التحقق من وجود السجل وتحديث بياناته
            if (car == null) return;
            car.Model = obj.Model;
            car.Gear = obj.Gear;
            car.Km = obj.Km;
            car.Year = obj.Year;
            car.Name = obj.Name;
            // حفظ التغييرات في قاعدة البيانات
            _context.SaveChanges();
            }
        }
    }
//********************يمكن تعميم التعليقات السابقة على جميع ال repositories  الموجودة لدينا
//CustomerRepositoy
//partRepositoy
//saleRepositoy
//supplierRepositoy