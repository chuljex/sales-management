using System;
using System.Collections.Generic;
using SalesManagement.Models;
using SalesManagement.utils;

namespace SalesManagement.Views
{
    public class MainView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly ProductView _productView = new ProductView();
        private readonly OrderView _orderView = new OrderView();
        private readonly CustomerView _customerView = new CustomerView();
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.WriteLine("Menu quản lý bán hàng");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Quản lý sản phẩm");
                Console.WriteLine("2. Quản lý đơn hàng");
                Console.WriteLine("3. Quản lý khách hàng");
                Console.WriteLine("0. Thoát");
                var menuChoice = _numberInputHandler.HandleIntInput();
                switch (menuChoice)
                {
                    case 1:
                        _productView.DisplayMenu();
                        break;
                    case 2:
                        Console.WriteLine("Menu 2");
                        _orderView.DisplayMenu();
                        break;
                    case 3:
                        Console.WriteLine("Menu 3");
                        _customerView.DisplayMenu();
                        break;
                    case 0:
                        Console.WriteLine("Thoát");
                        appRunning = false;
                        break;
                    default:
                        Console.WriteLine("Không có chức năng này!");
                        break;
                }
            }
        }
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
