using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;
using ConsoleTables;

namespace SalesManagement.Controllers
{
    public class ProductController
    {
        private SalesContext _context;

        public ProductController(SalesContext context) => _context = context;

        public IEnumerable<Product> GetAllProducts() => _context.Products;
        public void DisplayAllItems()
        {
            DisplayProduct(_context.Products, _context.ProductDetails);
        }

        public void DisplayProduct(List<Product> products, List<ProductDetail> productDetails)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = ["Mã", "Tên Sản Phẩm", "Giá", "Tồn Hàng", "Màu", "Cân Nặng", "Loại Đàn"],
                EnableCount = false
            });

            foreach (var product in products)
            {
                ProductDetail prodDetails = productDetails.FirstOrDefault(item => item.ProductId == product.ProductId);
                table.AddRow(product.ProductId, product.ProductName, product.Price, product.Stock, prodDetails.Color, prodDetails.Weight, prodDetails.Type);
            }

            table.Write();
        }

        public void Add(Product product, ProductDetail productDetail)
        {
            var id = _context.Products[_context.Products.Count - 1].ProductId + 1;
            product.ProductId = id;
            productDetail.ProductId = id;
            _context.Products.Add(product);
            _context.ProductDetails.Add(productDetail);
        }

        public Product GetProductById(int productId) =>
            _context.Products.FirstOrDefault(p => p.ProductId == productId);

        public void UpdateStock(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product != null) product.Stock -= quantity;
        }
    }
}
