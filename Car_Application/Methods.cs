using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Application
{
    public class Methods 
    {
        // إضافة الدوال الخاصة بالتعديل والحذف والقراءة والكتابة للسيارة
        //دالة الإضافة
        public int CreateCar(Car car)
        {
            //إنشاء سياق للتفاعل مع قاعدة البيانات مباشرةً
            using (var context = new Context())
            {
                //إضافة كائن السيارة مع حفظ التغييرات
                context.Add(car);
                context.SaveChanges();
            }
            //إعادة معرف السيارة التي تمت إضافتها
            return car.Id;
        }
        public int UpdateCar(Car car)
        {
            using (var context = new Context())
            {
                if (car != null)
                {
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                // إرجاع معرف السيارة (إذا لم تكن فارغة) بعد تحديثها
                return car != null ? car.Id : 0;
            }
        }
        public  int DeleteCar(int id)
        {
            using (var context = new Context())
            {
                // البحث عن السيارة باستخدام المعرف الخاص بها
                var car =  context.Cars.FirstOrDefault(c => c.Id == id);

                if (car != null)
                {
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                // إرجاع معرف السيارة (سواء تم الحذف أو لم يتم العثور عليها)
                return id;
            }
        }

        public int GetCar(int id)
        {
            using (var context = new Context())
           
            {
                var car =  context.Cars.FirstOrDefault(c => c.Id == id);
                if (car != null)
                {
                    return car.Id;
                }
                // في حالة عدم العثور على السيارة، يتم رفع استثناء DataMisalignedException
                throw new DataMisalignedException();
            }
        }
          // **************** يتم تعميم التعليقات على باقي الدوال الخاصة بالزبون والقطعة والمبيعات والمصنع ***************
        // إضافة الدوال الخاصة بالتعديل والحذف والقراءة والكتابة للزبون
        public int CreateCustomer(Customer customer)
        {
            using (var context = new Context())
            {
                context.Add(customer);
                context.SaveChanges();
            }
            return customer.Id;
        }

        public int UpdateCustomer(Customer customer)
        {
            using (var context = new Context())
            {
                if (customer != null)
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                return customer != null ? customer.Id : 0;
            }

        }
        public int DeleteCustomer(int id)
        {
            using (var context = new Context())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);

                if (customer != null)
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                return id;
            }
        }

        public int GetCustomer(int id)
        {
            using (var context = new Context())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);

                if (customer != null)
                {
                    return customer.Id;
                }
                throw new DataMisalignedException();
            }
        }

        // إضافة الدوال الخاصة بالتعديل والحذف والقراءة والكتابة للقطعة
        public int CreatePart(Part part)
        {
            using (var context = new Context())
            {
                context.Add(part);
                context.SaveChanges();
            }
            return part.Id;
        }
        public int UpdatePart(Part part)
        {
            using (var context = new Context())
            {
                if (part != null)
                {
                    context.Parts.Update(part);
                    context.SaveChanges();
                }
                return part != null ? part.Id : 0;
            }
        }
        public int DeletePart(int id)
        {
            using (var context = new Context())
            {
                var part = context.Parts.FirstOrDefault(c => c.Id == id);

                if (part != null)
                {
                    context.Parts.Update(part);
                    context.SaveChanges();
                }
                return id;
            }
        }
        public int GetPart(int id)
        {
            using (var context = new Context())
            {
                var part = context.Parts.FirstOrDefault(c => c.Id == id);

                if (part != null)
                {
                    return part.Id;
                }
                throw new DataMisalignedException();
            }
        }

        // إضافة الدوال الخاصة بالتعديل والحذف والقراءة والكتابة للمبيعات
        public int CreateSale(Sale sale)
        {
            using (var context = new Context())
            {
                context.Add(sale);
                context.SaveChanges();
            }
            return sale.Id;
        }
        public int UpdateSale(Sale sale)
        {
            using (var context = new Context())
            {
                if (sale != null)
                {
                    context.Sales.Update(sale);
                    context.SaveChanges();
                }
                return sale != null ? sale.Id : 0;
            }

        }
        public int DeleteSale(int id)
        {
            using (var context = new Context())
            {
                var sale = context.Sales.FirstOrDefault(c => c.Id == id);

                if (sale != null)
                {
                    context.Sales.Update(sale);
                    context.SaveChanges();
                }
                return id;
            }
        }
        public int GetSale(int id)
        {
            using (var context = new Context())
            {
                var sale = context.Sales.FirstOrDefault(c => c.Id == id);

                if (sale != null)
                {
                    return sale.Id;
                }
                throw new DataMisalignedException();
            }
        }

        // إضافة الدوال الخاصة بالتعديل والحذف والقراءة والكتابة للمصنع
        public int CreateSupplier(Supplier supplier)
        {
            using (var context = new Context())
            {
                context.Add(supplier);
                context.SaveChanges();
            }
            return supplier.Id;
        }
        public int UpdateSupplier(Supplier supplier)
        {
            using (var context = new Context())
            {
                if (supplier != null)
                {
                    context.Suppliers.Update(supplier);
                    context.SaveChanges();
                }
                return supplier != null ? supplier.Id : 0;
            }
        }
        public int DeleteSupplier(int id)
        {
            using (var context = new Context())
            {
                var supplier = context.Suppliers.FirstOrDefault(c => c.Id == id);

                if (supplier != null)
                {
                    context.Suppliers.Update(supplier);
                    context.SaveChanges();
                }
                return id;
            }
        }
        public int GetSupplier(int id)
        {
            using (var context = new Context())
            {
                var supplier = context.Suppliers.FirstOrDefault(c => c.Id == id);

                if (supplier != null)
                {
                    return supplier.Id;
                }
                throw new DataMisalignedException();
            }
        }
    }
}

