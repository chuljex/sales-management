using SalesManagement.Models;
using SalesManagement.Views;
using System.Collections.Generic;

namespace SalesManagement.Controllers
{
    public class ProductController
    {
        public void DisplayProducts()
        {
            List<Product> products = Product.GetAllProducts();
            ProductView.DisplayProductList(products);
        }

        public void AddProduct(string name, decimal price, int stock)
        {
            Product product = new Product { Name = name, Price = price, Stock = stock };
            product.Save();
        }
    }
}
