using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain
{
    public class Qualitative
    {
        public int Quantity { get; set; }
        public UnitEnum UnitEnum { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
