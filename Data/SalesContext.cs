using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Models;

namespace SalesManagement.Data
{
    public class SalesContext
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public SalesContext()
        {
            SeedData();
        }

        private void SeedData()
        {
            // Seed data for Products
            Products.AddRange(new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product A", Price = 100, Stock = 50 },
            new Product { ProductId = 2, ProductName = "Product B", Price = 200, Stock = 30 },
            new Product { ProductId = 3, ProductName = "Product C", Price = 300, Stock = 20 }
        });

            // Seed data for ProductDetails
            ProductDetails.AddRange(new List<ProductDetail>
        {
            new ProductDetail { ProductId = 1, Color = "Red", Weight = 1.5m, Type = "Type A" },
            new ProductDetail { ProductId = 2, Color = "Blue", Weight = 2.0m, Type = "Type B" },
            new ProductDetail { ProductId = 3, Color = "Green", Weight = 2.5m, Type = "Type C" }
        });

            // Seed data for Customers
            Customers.AddRange(new List<Customer>
        {
            new Customer { CustomerId = 1, CustomerName = "Alice", Email = "alice@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St" },
            new Customer { CustomerId = 2, CustomerName = "Bob", Email = "bob@example.com", PhoneNumber = "098-765-4321", Address = "456 Elm St" }
        });

            // Seed data for Orders
            Orders.AddRange(new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10), Status = "Shipped" },
            new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5), Status = "Processing" }
        });

            // Seed data for OrderDetails
            OrderDetails.AddRange(new List<OrderDetail>
        {
            new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, Price = 100 },
            new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, Price = 200 },
            new OrderDetail { OrderId = 2, ProductId = 3, Quantity = 3, Price = 300 }
        });
        }
    }
}
