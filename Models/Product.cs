using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Models
{
        public class Product
        {
                public int ProductId { get; set; }
                public string ProductName { get; set; }
                public decimal Price { get; set; }
                public int Stock { get; set; }
        }
}
