using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string Color { get; set; }
        public decimal Weight { get; set; }
        public string Type { get; set; }
    }
}