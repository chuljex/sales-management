using SalesManagement.Models;
using System;
using System.Linq;
using SalesManagement.Data;

namespace SalesManagement.Controllers
{
    public class OrderController
    {
        private SalesContext _context;

        public OrderController(SalesContext context) => _context = context;

        public IEnumerable<Order> GetAllOrders() => _context.Orders;

        public Order GetOrderById(int orderId) =>
            _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        public void PlaceOrder(int customerId, List<OrderItem> items)
        {
            var order = new Order
            {
                OrderId = _context.Orders.Count + 1,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                OrderItems = items
            };
            _context.Orders.Add(order);
        }
    }
}
