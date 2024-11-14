using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }  // Khóa ngoại đến Customer
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        
        // Danh sách các mục hàng của đơn hàng
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
