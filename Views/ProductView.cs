using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.Controllers;
using SalesManagement.Data;
using SalesManagement.Models;
using SalesManagement.utils;


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
                Console.WriteLine("Menu quản lý sản phẩm");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Xem tất cả sản phẩm");
                Console.WriteLine("2. Thêm sản phẩm");
                Console.WriteLine("3. Cập nhật sản phẩm");
                Console.WriteLine("4. Xóa sản phẩm");
                Console.WriteLine("0. Thoát");
                var menuChoice = _numberInputHandler.HandleIntInput();
                switch (menuChoice)
                {
                    case 1:
                        _productController.DisplayAllItems();
                        break;
                    case 2:
                        List<string> dataField = ["tên", "giá", "tồn hàng", "màu", "cân nặng", "loại"];
                        List<string> dataType = ["string", "decimal", "int", "string", "double", "string"];
                        var data = _addRecord.Add("đàn", dataField, dataType);
                        var newProd = new Product { ProductName = data[0], Price = decimal.Parse(data[1]), Stock = int.Parse(data[2]) };
                        var newProdDetails = new ProductDetail { Color = data[3], Weight = double.Parse(data[4]), Type = data[5] };
                        _productController.Add(newProd, newProdDetails);
                        break;
                    case 3:
                        Console.WriteLine("Menu 3");
                        break;
                    case 4:
                        Console.WriteLine("Menu 4");
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
    }
}