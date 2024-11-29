using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Data;
using SalesManagement.Models;

namespace SalesManagement.Views
{
    public class LinqView
    {
        private readonly SalesContext _context;

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
                Console.WriteLine("6. Lọc danh sách khách hàng theo khu vực cụ thể");
                Console.WriteLine("7. Tìm đơn hàng gần nhất của từng khách hàng");
                Console.WriteLine("8. Tính tuổi trung bình của khách hàng");
                Console.WriteLine("9. Lấy danh sách đơn hàng theo trạng thái");
                Console.WriteLine("10. Tìm 5 khách hàng chi tiêu nhiều nhất trong tháng hiện tại");
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
                        var lowStockProducts = _context.Products
                            .Where(p => p.Stock < 10)
                            .Select(p => new { p.ProductName, p.Stock })
                            .ToList();
                        DisplayList(lowStockProducts, "Sản phẩm tồn kho thấp:");
                        break;
                    // case 2:
                    //     var totalAmount = _context.OrderDetails
                    //         .Where(od => od.OrderId == od.OrderId)
                    //         .Sum(od => od.Quantity * od.Price);
                    //     var highestOrder = _context.Orders
                    //         .OrderByDescending(TotalAmount)
                    //         .FirstOrDefault();
                    //     Console.WriteLine(highestOrder != null
                    //         ? $"Đơn hàng có giá trị cao nhất: ID {highestOrder.OrderId}, Giá trị: {highestOrder.TotalAmount}"
                    //         : "Không có đơn hàng nào.");
                    //     break;
                    // case 3:
                    //     var yearlyRevenue = _context.Orders
                    //         .GroupBy(o => o.OrderDate.Year)
                    //         .Select(g => new { Year = g.Key, TotalRevenue = g.Sum(o => o.TotalAmount) })
                    //         .ToList();
                    //     DisplayList(yearlyRevenue, "Doanh thu theo năm:");
                    //     break;
                    case 4:
                        var firstOrdersThisYear = _context.Orders
                            .Where(o => o.OrderDate.Year == DateTime.Now.Year)
                            .GroupBy(o => o.CustomerId)
                            .Select(g => g.OrderBy(o => o.OrderDate).FirstOrDefault())
                            .ToList();
                        DisplayList(firstOrdersThisYear, "Đơn hàng đầu tiên trong năm của từng khách hàng:");
                        break;
                    case 5:
                        var productsNeverOrdered = _context.Products
                            .Where(p => !_context.OrderDetails.Any(od => od.ProductId == p.ProductId))
                            .Select(p => p.ProductName)
                            .ToList();
                        DisplayList(productsNeverOrdered, "Sản phẩm chưa từng được đặt hàng:");
                        break;
                    // case 6:
                    //     Console.Write("Nhập khu vực: ");
                    //     string region = Console.ReadLine();
                    //     var customersByRegion = _context.Customers
                    //         .Where(c => c.Region == region)
                    //         .Select(c => c.Name)
                    //         .ToList();
                    //     DisplayList(customersByRegion, $"Khách hàng trong khu vực {region}:");
                    //     break;
                    case 7:
                        var latestOrders = _context.Orders
                            .GroupBy(o => o.CustomerId)
                            .Select(g => g.OrderByDescending(o => o.OrderDate).FirstOrDefault())
                            .ToList();
                        DisplayList(latestOrders, "Đơn hàng gần nhất của từng khách hàng:");
                        break;
                    // case 8:
                    //     var averageAge = _context.Customers.Average(c => DateTime.Now.Year - c.BirthYear);
                    //     Console.WriteLine($"Tuổi trung bình của khách hàng: {averageAge:N1} năm");
                    //     break;
                    // case 9:
                    //     Console.Write("Nhập trạng thái đơn hàng: ");
                    //     string status = Console.ReadLine();
                    //     var ordersByStatus = _context.Orders
                    //         .Where(o => o.Status == status)
                    //         .Select(o => new { o.OrderId, o.OrderDate, o.TotalAmount })
                    //         .ToList();
                    //     DisplayList(ordersByStatus, $"Danh sách đơn hàng với trạng thái '{status}':");
                    //     break;
                    // case 10:
                    //     var topCustomersThisMonth = _context.Orders
                    //         .Where(o => o.OrderDate.Month == DateTime.Now.Month && o.OrderDate.Year == DateTime.Now.Year)
                    //         .GroupBy(o => o.CustomerId)
                    //         .Select(g => new { CustomerId = g.Key, TotalSpent = g.Sum(o => o.TotalAmount) })
                    //         .OrderByDescending(c => c.TotalSpent)
                    //         .Take(5)
                    //         .ToList();
                    //     DisplayList(topCustomersThisMonth, "Top 5 khách hàng chi tiêu nhiều nhất tháng này:");
                    //     break;
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