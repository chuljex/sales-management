using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.Controllers;
using SalesManagement.Data;
using SalesManagement.Models;
using SalesManagement.utils;
using SalesManagement.services;

namespace SalesManagement.Views
{
    public class CustomerView
    {
        private readonly CustomerController _customerController;
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly AddRecord _addRecord = new AddRecord();

        public CustomerView(SalesContext context)
        {
            _customerController = new CustomerController(context);
        }
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu quản lý khách hàng");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Xem tất cả khách hàng");
                Console.WriteLine("2. Thêm khách hàng");
                Console.WriteLine("3. Cập nhật thông tin khách hàng");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");
                var menuChoice = _numberInputHandler.HandleIntInput(false);
                switch (menuChoice)
                {
                    case 1:
                        _customerController.DisplayAllItems();
                        break;
                    case 2:
                        List<string> dataField = ["tên", "email", "số điện thoại", "địa chỉ"];
                        List<string> dataType = ["string", "string", "string", "string"];
                        var data = _addRecord.Add("khách hàng", dataField, dataType);
                        var newCustomer = new Customer { CustomerName = data[0], Email = data[1], PhoneNumber = data[2], Address = data[3] };
                        _customerController.Add(newCustomer);
                        break;
                    case 3:
                        Console.WriteLine("Chọn khách hàng cần cập nhật:");
                        _customerController.DisplayAllItems();
                        Console.Write("Lựa chọn của bạn: ");
                        var id = _numberInputHandler.HandleIntInput(false);
                        _customerController.Update(id);
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