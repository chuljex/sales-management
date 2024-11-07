using SalesManagement.Controllers;
using SalesManagement.Views;
using System;

namespace SalesManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductController productController = new ProductController();

            Console.WriteLine("Hệ thống quản lý bán hàng");
            Console.WriteLine("1. Xem danh sách sản phẩm");
            Console.WriteLine("2. Thêm sản phẩm mới");
            Console.Write("Chọn một tùy chọn: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    productController.DisplayProducts();
                    break;
                case 2:
                    ProductView.AddProductPrompt(productController);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}
