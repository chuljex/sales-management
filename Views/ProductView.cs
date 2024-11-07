using SalesManagement.Models;
using System;
using System.Collections.Generic;

namespace SalesManagement.Views
{
    public static class ProductView
    {
        public static void DisplayProductList(List<Product> products)
        {
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Tên: {product.Name}, Giá: {product.Price}, Tồn kho: {product.Stock}");
            }
        }

        public static void AddProductPrompt(ProductController controller)
        {
            Console.WriteLine("Thêm sản phẩm mới:");
            Console.Write("Tên sản phẩm: ");
            string name = Console.ReadLine();
            Console.Write("Giá: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Tồn kho: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            controller.AddProduct(name, price, stock);
            Console.WriteLine("Đã thêm sản phẩm thành công.");
        }
    }
}
