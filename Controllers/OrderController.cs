using SalesManagement.Models;
using System;
using System.Linq;
using SalesManagement.Data;
using ConsoleTables;

namespace SalesManagement.Controllers
{
    public class OrderController
    {
        private SalesContext _context;

        public OrderController(SalesContext context) => _context = context;

        public IEnumerable<Order> GetAllOrders() => _context.Orders;

        public Order GetOrderById(int orderId) =>
            _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        public void DisplayAllItems()
        {
            DisplayOrder(_context.Orders);
        }

        public void DisplayOrder(List<Order> orders)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = ["Mã Đơn", "Mã Khách Hàng", "Ngày Đặt", "Trạng Thái"],
                EnableCount = false
            });

            foreach (var order in orders)
            {
                table.AddRow(order.OrderId, order.CustomerId, order.OrderDate, order.Status);
            }

            table.Write();
        }

        public void Add(Order order)
        {
            var id = _context.Orders[_context.Orders.Count - 1].OrderId + 1;
            order.OrderId = id;
            // orderDetails.OrderId = id;
            _context.Orders.Add(order);
            // _context.OrderDetails.Add(orderDetails);
        }
    }
}
