using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.utils;


namespace SalesManagement.Views
{
    public class ProductView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
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
                Console.WriteLine("5. Tìm kiếm sản phẩm");
                Console.WriteLine("0. Thoát");
                var menuChoice = _numberInputHandler.HandleIntInput();
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("Menu 1");
                        break;
                    case 2:
                        Console.WriteLine("Menu 2");
                        break;
                    case 3:
                        Console.WriteLine("Menu 3");
                        break;
                    case 4:
                        Console.WriteLine("Menu 4");
                        break;
                    case 5:
                        Console.WriteLine("Menu 5");
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