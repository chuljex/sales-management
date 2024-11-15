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
            // var running = true;
            // while (running)
            // {
            //     Console.WriteLine("Menu hệ thống:");
            //     Console.WriteLine("1. Xem sản phẩm:");
            // }
            var context = new SalesContext();
            var productController = new ProductController(context);
            var customerController = new CustomerController(context);
            var orderController = new OrderController(context);
            var view = new ConsoleView();

            // Hiển thị danh sách sản phẩm
            view.DisplayProducts(productController.GetAllProducts());

            // LINQ Queries
            // var availableProducts = context.Products.Where(p => p.StockQuantity > 0);
            var highValueOrders = context.Orders
            .Where(order => order.OrderItems
            .Sum(order_item => order_item.Quantity * context.Products.FirstOrDefault(product => product.ProductId == order_item.ProductId).Price) > 500);

            Console.WriteLine("LINQ Query Results:");
            // Console.WriteLine("Available Products: " + availableProducts.Count());
            Console.WriteLine("High Value Orders: " + highValueOrders.Count());
        }
    }
}
