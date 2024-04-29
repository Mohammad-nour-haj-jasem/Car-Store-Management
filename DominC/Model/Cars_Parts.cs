using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominC.Model
{
    public class Cars_Parts
    {
        public int CarId { get; set; }
        public Car car { get; set; }
        public int PartId { get; set; }
        public Part part { get; set; }
    }
}
