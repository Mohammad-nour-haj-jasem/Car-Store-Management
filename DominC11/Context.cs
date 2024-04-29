using DominC.Model;
using Microsoft.EntityFrameworkCore;

namespace DominC11
{
    public class APIContext : DbContext
    { 
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        //تعريف مجموعة البيانات لكائنات السيارة
        public DbSet<Car> Cars {  get; set; }
        //تعريف مجموعة البيانات لكائنات الزبون
        public DbSet<Customer> Customers { get; set; }
        //تعريف مجموعة البيانات لكائنات القطعة
        public DbSet<Part> Parts { get; set; }
        //تعريف مجموعة البيانات لكائنات المبيعات
        public DbSet<Sale> Sales{ get; set; }
        //تعريف مجموعة البيانات لكائنات المصنع
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Cars_Parts> Cars_Parts { get; set;}
        // يتم استدعاء هذه الوظيفة عند تكوين السياق المطلوب

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                        .HasMany(c => c.Part)
                        .WithMany(p => p.Cars)
                        .UsingEntity<Cars_Parts>();

            base.OnModelCreating(modelBuilder);
        }


    }
}