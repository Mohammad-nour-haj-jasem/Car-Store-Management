using DominC;
using DominC.Model;
using DominC11;
namespace Car_Application

{
    public class Program
    {
        static  void Main(string[] args)
        {
            //إضافة سيارة
            var car = new Car();    
            car.Model = "BUGATTI CHIRON";
            car.Gear = "7";
            car.Year = DateTime.UtcNow;
            car.Km = 420;
            car.Name = "Samer abo samra";
            var C1 = new Methods();
            C1.CreateCar(car);
            //إضافة قطعة
            var part = new Part();
            part.Price = 2500000; //2.5 M$
            part.Quantity = 20;
            part.SupplierId = 009;
            part.supplier = new Supplier();
            part.Cars = new List<Car>();
            var p1 = new Methods();
            p1.CreatePart(part);
            //إضافة مُصنٍّع
            var supplier = new Supplier();
            supplier.Name = "VOLKSWAGEN";
            supplier.Address = "FRANCE";
            supplier.Parts = new List<Part>();
            var s1 = new Methods();
            s1.CreateSupplier(supplier);
          
        }




    }
}