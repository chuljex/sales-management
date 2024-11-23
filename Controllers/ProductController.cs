using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;

namespace SalesManagement.Controllers
{
    public class ProductController
    {
        private SalesContext _context;

        public ProductController(SalesContext context) => _context = context;

        public IEnumerable<Product> GetAllProducts() => _context.Products;

        public Product GetProductById(int productId) =>
            _context.Products.FirstOrDefault(p => p.ProductId == productId);

        public void UpdateStock(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product != null) product.Stock -= quantity;
        }
    }
}
