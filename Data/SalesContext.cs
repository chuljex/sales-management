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
                new Product { ProductId = 2, ProductName = "Product B", Price = 200, Stock = 7 },
                new Product { ProductId = 3, ProductName = "Product C", Price = 300, Stock = 20 },
                new Product { ProductId = 4, ProductName = "Product D", Price = 400, Stock = 15 },
                new Product { ProductId = 5, ProductName = "Product E", Price = 150, Stock = 5 }
            });

            // Seed data for ProductDetails
            ProductDetails.AddRange(new List<ProductDetail>
            {
                new ProductDetail { ProductId = 1, Color = "Red", Weight = 1.5, Type = "Type A" },
                new ProductDetail { ProductId = 2, Color = "Blue", Weight = 2.0, Type = "Type B" },
                new ProductDetail { ProductId = 3, Color = "Green", Weight = 2.5, Type = "Type C" },
                new ProductDetail { ProductId = 4, Color = "Yellow", Weight = 1.8, Type = "Type D" },
                new ProductDetail { ProductId = 5, Color = "Purple", Weight = 1.2, Type = "Type E" }
            });

            // Seed data for Customers
            Customers.AddRange(new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice", Email = "alice@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St" },
                new Customer { CustomerId = 2, CustomerName = "Bob", Email = "bob@example.com", PhoneNumber = "098-765-4321", Address = "456 Elm St" },
                new Customer { CustomerId = 3, CustomerName = "Charlie", Email = "charlie@example.com", PhoneNumber = "555-111-2222", Address = "789 Maple Ave" },
                new Customer { CustomerId = 4, CustomerName = "Daisy", Email = "daisy@example.com", PhoneNumber = "555-333-4444", Address = "101 Oak St" }
            });

            // Seed data for Orders
            Orders.AddRange(new List<Order>
            {
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10), Status = "Shipped" },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5), Status = "Processing" },
                new Order { OrderId = 3, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-2), Status = "Delivered" },
                new Order { OrderId = 4, CustomerId = 4, OrderDate = DateTime.Now.AddDays(-1), Status = "Pending" }
            });

            // Seed data for OrderDetails
            OrderDetails.AddRange(new List<OrderDetail>
            {
                new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, Price = 100 },
                new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, Price = 200 },
                new OrderDetail { OrderId = 2, ProductId = 3, Quantity = 3, Price = 300 },
                new OrderDetail { OrderId = 3, ProductId = 4, Quantity = 2, Price = 400 },
                new OrderDetail { OrderId = 3, ProductId = 5, Quantity = 1, Price = 150 },
                new OrderDetail { OrderId = 4, ProductId = 2, Quantity = 4, Price = 200 },
                new OrderDetail { OrderId = 4, ProductId = 1, Quantity = 3, Price = 100 }
            });
        }
    }
}
