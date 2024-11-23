using System;
using SalesManagement.Controllers;
using SalesManagement.Models;
using SalesManagement.Views;
using SalesManagement.Data;

namespace SalesManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();
            var productController = new ProductController(context);
            var customerController = new CustomerController(context);
            var orderController = new OrderController(context);
            var view = new ConsoleView();

            // Hiển thị danh sách sản phẩm
            view.DisplayProducts(productController.GetAllProducts());

            // LINQ Queries
            // Lấy danh sách tất cả khách hàng
            var customers = context.Customers.ToList();
            // Lấy thông tin đơn hàng của khách hàng cụ thể
            int customerId = 1;
            var customerOrders = context.Orders.Where(o => o.CustomerId == customerId).ToList();

            Console.WriteLine("LINQ Query Results:");

            // Lấy danh sách tất cả khách hàng
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.CustomerName}, Email: {customer.Email}");
            }

            // Lấy thông tin đơn hàng của khách hàng cụ thể
            foreach (var order in customerOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Status: {order.Status}");
            }
        }
    }
}
