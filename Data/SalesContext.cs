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
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<ShopStock> ShopStocks { get; set; } = new List<ShopStock>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
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
                new Product { ProductId = 1, ProductName = "Product A", Price = 100},
                new Product { ProductId = 2, ProductName = "Product B", Price = 200},
                new Product { ProductId = 3, ProductName = "Product C", Price = 300}
            });

            // Khởi tạo dữ liệu mẫu cho Customers
            Customers.AddRange(new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice", Email = "alice@example.com" },
                new Customer { CustomerId = 2, CustomerName = "Bob", Email = "bob@example.com" }
            });

            // Khởi tạo dữ liệu mẫu cho Shops
            Shops.AddRange(new List<Shop> {
                new Shop { ShopId = 1, Address = "111 Mars", City = "New York", StaffLimit = 5},
                new Shop { ShopId = 2, Address = "321 Mercury", City = "Los Angeles", StaffLimit = 7}
            });

            // Khỏi tạo dữ liệu mẫu cho Employees
            Employees.AddRange(new List<Employee> {
                new Employee { EmployeeId = 1, Name = "Franky", Age = 19, PhoneNumber = 1234567890, ShopId = 1},
                new Employee { EmployeeId = 2, Name = "Muller", Age = 21, PhoneNumber = 0987654321, ShopId = 2},
            });

            // Khỏi tạo dữ liệu mẫu cho ShopStocks
            ShopStocks.AddRange(new List<ShopStock> {
                new ShopStock { ShopId = 1, ProductId = 1, StockQuantity = 10},
                new ShopStock { ShopId = 1, ProductId = 2, StockQuantity = 40},
                new ShopStock { ShopId = 1, ProductId = 3, StockQuantity = 20},
                new ShopStock { ShopId = 2, ProductId = 1, StockQuantity = 15},
                new ShopStock { ShopId = 2, ProductId = 2, StockQuantity = 12},
                new ShopStock { ShopId = 2, ProductId = 3, StockQuantity = 35},
            });

            // Khởi tạo dữ liệu mẫu cho Orders và OrderItems
            Orders.Add(new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDate = DateTime.Now.AddDays(-2),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2, OrderId = 1},
                    new OrderItem { ProductId = 2, Quantity = 1, OrderId = 1}
                }
            });

            Orders.Add(new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 3, Quantity = 3, OrderId = 2}
                }
            });
        }
    }
}
