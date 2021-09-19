using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
