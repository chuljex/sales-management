using System;
using System.Collections.Generic;
using SalesManagement.Data;
using SalesManagement.Models;
using SalesManagement.utils;

namespace SalesManagement.Views
{
    public class MainView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly ProductView _productView;
        private readonly OrderView _orderView;
        private readonly CustomerView _customerView;
        private readonly LinqView _linqView;
        public MainView(SalesContext context)
        {
            _productView = new ProductView(context);
            _orderView = new OrderView(context);
            _customerView = new CustomerView(context);
            _linqView = new LinqView(context);
        }
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu quản lý bán hàng");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Quản lý sản phẩm");
                Console.WriteLine("2. Quản lý đơn hàng");
                Console.WriteLine("3. Quản lý khách hàng");
                Console.WriteLine("4. Thống kê");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");
                var menuChoice = _numberInputHandler.HandleIntInput(false);
                switch (menuChoice)
                {
                    case 1:
                        _productView.DisplayMenu();
                        break;
                    case 2:
                        _orderView.DisplayMenu();
                        break;
                    case 3:
                        _customerView.DisplayMenu();
                        break;
                    case 4:
                        _linqView.DisplayMenu();
                        break;
                    case 0:
                        Console.WriteLine("Tạm biệt!");
                        appRunning = false;
                        break;
                    default:
                        Console.WriteLine("Không có chức năng này!");
                        Console.WriteLine("Nhấn Enter để tiếp tục...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
