using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain
{
    public class Stock
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }  
        public Qualitative PurchaseInformation { get; set; }
    }
}
