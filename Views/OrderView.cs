using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.utils;

namespace SalesManagement.Views
{
    public class OrderView
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        public void DisplayMenu()
        {
            var appRunning = true;
            while (appRunning)
            {
                Console.WriteLine("Menu quản lý đơn hàng");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Xem tất cả đơn hàng");
                Console.WriteLine("2. Tạo đơn hàng");
                Console.WriteLine("3. Cập nhật đơn hàng");
                Console.WriteLine("4. Cập nhật trạng thái đơn hàng");
                Console.WriteLine("5. Tìm kiếm đơn hàng");
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