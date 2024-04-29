using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominC.Model
{
    //كلاس يحوي معلومات حول المبيعات
    public class Sale : BClass
    {
        public int Total { get; set; }
        public Car car { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
