using System.Collections.Generic;

namespace SalesManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        
        // Danh sách đơn hàng của khách hàng
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
