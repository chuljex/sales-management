using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Models;

namespace SalesManagement.Data
{
    public class SalesContext
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public SalesContext()
        {
            SeedData();
        }

        private void SeedData()
        {
            // Khởi tạo dữ liệu mẫu cho Products
            Products.AddRange(new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Product A", Price = 100, StockQuantity = 50 },
                new Product { ProductId = 2, ProductName = "Product B", Price = 200, StockQuantity = 30 },
                new Product { ProductId = 3, ProductName = "Product C", Price = 300, StockQuantity = 20 }
            });

            // Khởi tạo dữ liệu mẫu cho Customers
            Customers.AddRange(new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice", Email = "alice@example.com" },
                new Customer { CustomerId = 2, CustomerName = "Bob", Email = "bob@example.com" }
            });

            // Khởi tạo dữ liệu mẫu cho Orders và OrderItems
            Orders.Add(new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDate = DateTime.Now.AddDays(-2),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { OrderItemId = 1, ProductId = 1, Quantity = 2, Product = Products.First(p => p.ProductId == 1) },
                    new OrderItem { OrderItemId = 2, ProductId = 2, Quantity = 1, Product = Products.First(p => p.ProductId == 2) }
                }
            });

            Orders.Add(new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { OrderItemId = 3, ProductId = 3, Quantity = 3, Product = Products.First(p => p.ProductId == 3) }
                }
            });
        }
    }
}
