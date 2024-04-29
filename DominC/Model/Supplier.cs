using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominC.Model
{
    //كلاس يحوي معلومات حول المصنع
    public class Supplier : BClass
    {
        public string Address { get; set; }
        public List<Part> Parts { get; set; } = new List<Part>();

    }
}
