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
    public class ProductView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly AddRecord _addRecord = new AddRecord();
        private readonly ProductController _productController;

        public ProductView(SalesContext context)
        {
            _productController = new ProductController(context);
        }
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu quản lý sản phẩm");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Xem tất cả sản phẩm");
                Console.WriteLine("2. Thêm sản phẩm");
                Console.WriteLine("3. Cập nhật sản phẩm");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");
                var menuChoice = _numberInputHandler.HandleIntInput(false);
                switch (menuChoice)
                {
                    case 1:
                        _productController.DisplayAllItems();
                        break;
                    case 2:
                        List<string> dataField = ["tên", "giá", "tồn hàng", "màu", "cân nặng (kg)", "loại"];
                        List<string> dataType = ["string", "decimal", "int", "string", "double", "string"];
                        var data = _addRecord.Add("đàn", dataField, dataType);
                        var newProd = new Product { ProductName = data[0], Price = decimal.Parse(data[1]), Stock = int.Parse(data[2]) };
                        var newProdDetails = new ProductDetail { Color = data[3], Weight = double.Parse(data[4]), Type = data[5] };
                        _productController.Add(newProd, newProdDetails);
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