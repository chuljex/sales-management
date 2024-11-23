using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }  // Khóa ngoại đến Customer
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
