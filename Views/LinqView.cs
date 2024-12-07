using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Data;
using SalesManagement.Models;
using SalesManagement.utils;
using ConsoleTables;

namespace SalesManagement.Views
{
    public class LinqView
    {
        private readonly SalesContext _context;
        private readonly Table _table = new Table();

        private readonly HandleTextInput _handleTextInput = new HandleTextInput();

        public LinqView(SalesContext context)
        {
            _context = context;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== THỐNG KÊ MỚI ===");
                Console.WriteLine("1. Lấy danh sách sản phẩm tồn kho thấp");
                Console.WriteLine("2. Tìm đơn hàng có giá trị cao nhất");
                Console.WriteLine("3. Thống kê doanh thu theo từng năm");
                Console.WriteLine("4. Lấy danh sách khách hàng có đơn hàng đầu tiên trong năm hiện tại");
                Console.WriteLine("5. Tìm sản phẩm chưa từng được đặt hàng");
                Console.WriteLine("6. Tìm sản phẩm được đặt hàng nhiều nhất");
                Console.WriteLine("7. Tìm đơn hàng gần nhất của từng khách hàng");
                Console.WriteLine("8. Thống kê tổng số lượng sản phẩm bán ra theo loại sản phẩm");
                Console.WriteLine("9. Lấy danh sách đơn hàng theo trạng thái");
                Console.WriteLine("10. Tìm 3 khách hàng chi tiêu nhiều nhất trong tháng hiện tại");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ! Nhấn Enter để tiếp tục...");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        var lowStock = 10;
                        var lowStockProducts = _context.Products
                            .Where(p => p.Stock < lowStock)
                            .Select(p => new { p.ProductName, p.Stock })
                            .ToList();
                        if (lowStockProducts == null)
                        {
                            Console.WriteLine($"Không có sản phẩm nào có tồn kho < hơn {lowStock}!");
                            break;
                        }
                        _table.Display(lowStockProducts, ["Tên sản phẩm", "Tồn hàng"], "Sản phẩm tồn kho thấp:");
                        break;
                    case 2:
                        var orderGroups = from orders in _context.Orders
                                          join orderDetails in _context.OrderDetails on orders.OrderId equals orderDetails.OrderId
                                          group new { orders, orderDetails.Price, orderDetails.Quantity } by new { orders.OrderId, orders.CustomerId, orders.OrderDate } into orderGroup
                                          select new
                                          {
                                              orderGroup.Key.OrderId,
                                              orderGroup.Key.CustomerId,
                                              orderGroup.Key.OrderDate,
                                              TotalValue = orderGroup.Sum(o => o.Price * o.Quantity)
                                          };
                        var maxTotalValue = orderGroups.Max(og => og.TotalValue);
                        var highestOrder = orderGroups.Where(og => og.TotalValue == maxTotalValue);
                        if (highestOrder == null)
                        {
                            Console.WriteLine("Không có đơn hàng nào!");
                            break;
                        }
                        _table.Display(highestOrder.ToList(), ["Mã Đơn Hàng", "Mã Khách Hàng", "Ngày", "Tổng Tiền"], "Đơn hàng có giá trị cao nhất:");
                        break;
                    case 3:
                        // var yearlyRevenue = _context.Orders
                        //     .GroupBy(o => o.OrderDate.Year)
                        //     .Select(g => new
                        //     {
                        //         Year = g.Key,
                        //         TotalRevenue = g.Sum(o =>
                        //         {
                        //             return _context.OrderDetails.Where(od => od.OrderId == o.OrderId).Sum(details => details.Quantity * details.Price);
                        //         })
                        //     })
                        //     .ToList();
                        var yearlyRevenue = from orders in _context.Orders
                                            join orderDetails in _context.OrderDetails on orders.OrderId equals orderDetails.OrderId
                                            group new { orders, orderDetails.Price, orderDetails.Quantity } by orders.OrderDate.Year into orderGroup
                                            select new
                                            {
                                                Year = orderGroup.Key,
                                                TotalRevenue = orderGroup.Sum(o => o.Price * o.Quantity)
                                            };
                        _table.Display(yearlyRevenue.ToList(), ["Năm", "Doanh Thu"], "Doanh thu theo năm:");
                        break;
                    case 4:
                        var firstOrdersThisYear = _context.Orders
                            .Where(o => o.OrderDate.Year == DateTime.Now.Year)
                            .GroupBy(o => o.CustomerId)
                            .Select(g => g.OrderBy(o => o.OrderDate).FirstOrDefault())
                            .ToList();
                        _table.Display(firstOrdersThisYear, ["Mã Đơn Hàng", "Mã Khách Hàng", "Ngày", "Trạng Thái"], "Đơn hàng đầu tiên trong năm của từng khách hàng:");
                        break;
                    case 5:
                        var productsNeverOrdered = _context.Products
                            .Where(p => !_context.OrderDetails.Any(od => od.ProductId == p.ProductId))
                            .ToList();
                        _table.Display(productsNeverOrdered, ["Mã", "Tên Sản Phẩm", "Giá", "Tồn Hàng"], "Sản phẩm chưa từng được đặt hàng:");
                        break;
                    case 6:
                        var mostOrderedProduct = _context.OrderDetails
                            .GroupBy(od => od.ProductId)
                            .Select(g => new
                            {
                                ProductId = g.Key,
                                TotalQuantity = g.Sum(od => od.Quantity),
                                ProductName = _context.Products.FirstOrDefault(p => p.ProductId == g.Key)?.ProductName
                            })
                            .OrderByDescending(p => p.TotalQuantity)
                            .FirstOrDefault();

                        if (mostOrderedProduct != null)
                        {
                            Console.WriteLine($"Sản phẩm được đặt hàng nhiều nhất: {mostOrderedProduct.ProductName}, Tổng số lượng: {mostOrderedProduct.TotalQuantity}");
                        }
                        else
                        {
                            Console.WriteLine("Không có sản phẩm nào.");
                        }
                        break;
                    case 7:
                        var latestOrders = _context.Orders
                            .GroupBy(o => o.CustomerId)
                            .Select(g => g.OrderByDescending(o => o.OrderDate).FirstOrDefault())
                            .ToList();
                        _table.Display(latestOrders, ["Mã Đơn Hàng", "Mã Khách Hàng", "Ngày", "Trạng Thái"], "Đơn hàng gần nhất của từng khách hàng:");
                        break;
                    case 8:
                        var salesByCategory = from product in _context.Products
                                              join order_details in _context.OrderDetails on product.ProductId equals order_details.ProductId
                                              join product_details in _context.ProductDetails on product.ProductId equals product_details.ProductId
                                              group new { product, order_details.Quantity } by product_details.Type into productGroup
                                              select new
                                              {
                                                  Type = productGroup.Key,
                                                  TotalQuantity = productGroup.Sum(g => g.Quantity)
                                              };
                        _table.Display(salesByCategory.ToList(), ["Loại sản phẩm", "Tổng số lượng"], "Tổng số lượng sản phẩm bán ra theo loại sản phẩm:");
                        break;
                    case 9:
                        Console.Write("Nhập trạng thái đơn hàng: ");
                        string status = _handleTextInput.HandleStringInput();
                        var ordersByStatus = _context.Orders
                            .Where(o => o.Status == status)
                            .ToList();
                        _table.Display(ordersByStatus, ["Mã Đơn Hàng", "Mã Khách Hàng", "Ngày", "Trạng Thái"], $"Danh sách đơn hàng với trạng thái '{status}':");
                        break;
                    case 10:
                        // var topCustomersThisMonth = _context.Orders
                        //     .Where(o => o.OrderDate.Month == DateTime.Now.Month && o.OrderDate.Year == DateTime.Now.Year)
                        //     .GroupBy(o => o.CustomerId)
                        //     .Select(g => new { CustomerId = g.Key, TotalSpent = g.Sum(o => o.TotalAmount) })
                        //     .OrderByDescending(c => c.TotalSpent)
                        //     .Take(3)
                        //     .ToList();
                        var topCustomersThisMonth = (from orders in _context.Orders
                                                     join customers in _context.Customers on orders.CustomerId equals customers.CustomerId
                                                     join orderDetails in _context.OrderDetails on orders.OrderId equals orderDetails.OrderId
                                                     where orders.OrderDate.Month == DateTime.Now.Month && orders.OrderDate.Year == DateTime.Now.Year
                                                     group new { customers, orders, orderDetails.Price, orderDetails.Quantity } by customers into orderGroup
                                                     select new
                                                     {
                                                         orderGroup.Key.CustomerId,
                                                         orderGroup.Key.CustomerName,
                                                         orderGroup.Key.Email,
                                                         orderGroup.Key.PhoneNumber,
                                                         TotalValue = orderGroup.Sum(o => o.Price * o.Quantity)
                                                     }).OrderByDescending(o => o.TotalValue).Take(3);
                        _table.Display(topCustomersThisMonth.ToList(), ["Mã khách hàng", "Tên khách hàng", "Email", "SĐT", "Tổng chi tiêu"], "Top 3 khách hàng chi tiêu nhiều nhất tháng này:");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("Nhấn Enter để quay lại menu...");
                Console.ReadLine();
            }
        }

        private static void DisplayList<T>(IEnumerable<T> items, string title)
        {
            Console.WriteLine(title);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}