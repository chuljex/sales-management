using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.utils;
using SalesManagement.Data;
using SalesManagement.Controllers;
using SalesManagement.Models;
using SalesManagement.services;

namespace SalesManagement.Views
{
    public class OrderView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly OrderController _orderController;
        private readonly CustomerController _customerController;
        private readonly ProductController _productController;
        private readonly AddRecord _addRecord = new AddRecord();
        public OrderView(SalesContext context)
        {
            _orderController = new OrderController(context);
        }
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu quản lý đơn hàng");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Xem tất cả đơn hàng");
                Console.WriteLine("2. Tạo đơn hàng");
                Console.WriteLine("3. Cập nhật đơn hàng");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");
                var menuChoice = _numberInputHandler.HandleIntInput(false);
                switch (menuChoice)
                {
                    case 1:
                        _orderController.DisplayAllItems();
                        break;
                    case 2:
                        List<string> dataField = ["mã"];
                        List<string> dataType = ["int"];
                        var data = _addRecord.Add("khách hàng", dataField, dataType);
                        var newOrder = new Order { CustomerId = int.Parse(data[0]) };
                        _orderController.Add(newOrder);
                        break;
                    case 3:
                        Console.WriteLine("Menu 3");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Không có chức năng này!");
                        break;
                }
                Console.WriteLine("Nhấn Enter để quay lại menu...");
                Console.ReadLine();
            }
        }
    }
}