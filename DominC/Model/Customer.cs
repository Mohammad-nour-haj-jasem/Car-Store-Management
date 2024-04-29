using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominC.Model
{
    //كلاس يحوي معلومات حول الزبون
    public class Customer : BClass
    {
        public int Age { get; set; }
        public string? Address { get; set; }
    }
}
