using System;
using System.Collections.Generic;
using SalesManagement.Models;

namespace SalesManagement.Views
{
    public class ConsoleView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("Product List:");
            foreach (var product in products)
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}, Stock: {product.Stock}");
        }

        public void DisplayCustomers(IEnumerable<Customer> customers)
        {
            Console.WriteLine("Customer List:");
            foreach (var customer in customers)
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.CustomerName}, Email: {customer.Email}");
        }
    }
}
