using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;

namespace SalesManagement.Controllers
{
    public class ShopController
    {
        private SalesContext _context;

        public ShopController(SalesContext context) => _context = context;

        public IEnumerable<Shop> GetAllShops() => _context.Shops;

        public Shop GetShopById(int shopId) =>
            _context.Shops.FirstOrDefault(p => p.ShopId == shopId);

        public void UpdateStock(int shopId, int productId, int quantity)
        {
            var shop = GetShopById(shopId);
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && shop != null)
            {
                var shopStock = _context.ShopStocks
                .FirstOrDefault(st => st.ShopId == shopId && st.ProductId == productId);
                if (shopStock != null)
                {
                    shopStock.StockQuantity = quantity;
                }
            }
        }
    }
}
