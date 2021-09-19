using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Stock Stock { get; set; } = default;
    }
}
