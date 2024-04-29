using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominC.Model
{
    //كلاس يحوي معلومات حول القطعة
    public class Part : BClass
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public Supplier? supplier { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();


    }
}
