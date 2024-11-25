using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Models;

class LinqQueries
{
    public void ExecuteQueries(List<Customer> customers, List<Order> orders)
    {
        // 1. Lấy danh sách tất cả khách hàng
        var allCustomers = customers.ToList();
        Console.WriteLine("Danh sách khách hàng:");
        allCustomers.ForEach(c => Console.WriteLine(c.CustomerName));

        // 2. Lấy đơn hàng của một khách hàng cụ thể (theo ID)
        int specificCustomerId = 1; // Thay bằng ID cần tìm
        var customerOrders = orders.Where(o => o.CustomerId == specificCustomerId).ToList();
        Console.WriteLine($"Đơn hàng của khách hàng ID {specificCustomerId}:");
        customerOrders.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}, Date: {o.OrderDate}"));

        // 3. Tìm khách hàng có doanh thu cao nhất
        var topCustomer = orders
            .GroupBy(o => o.CustomerId)
            .OrderByDescending(g => g.Count()) // Giả định số lượng đơn hàng là doanh thu
            .Select(g => new { CustomerId = g.Key, OrderCount = g.Count() })
            .FirstOrDefault();
        if (topCustomer != null)
        {
            Console.WriteLine($"Khách hàng có nhiều đơn hàng nhất: {topCustomer.CustomerId}, Số đơn: {topCustomer.OrderCount}");
        }

        // 4. Lọc danh sách đơn hàng theo trạng thái (ví dụ: "Completed")
        var completedOrders = orders.Where(o => o.Status == "Completed").ToList();
        Console.WriteLine("Danh sách đơn hàng đã hoàn thành:");
        completedOrders.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}, Date: {o.OrderDate}"));

        // 5. Kết hợp dữ liệu từ khách hàng và đơn hàng để hiển thị báo cáo chi tiết
        var customerOrderReport = customers
            .Join(orders,
                  c => c.CustomerId,
                  o => o.CustomerId,
                  (c, o) => new { c.CustomerName, o.OrderId, o.OrderDate, o.Status })
            .ToList();
        Console.WriteLine("Báo cáo chi tiết khách hàng và đơn hàng:");
        customerOrderReport.ForEach(r => Console.WriteLine($"{r.CustomerName} - Order ID: {r.OrderId}, Date: {r.OrderDate}, Status: {r.Status}"));

        // 6. Thống kê tổng số lượng đơn hàng của từng khách hàng
        var orderCountByCustomer = orders
            .GroupBy(o => o.CustomerId)
            .Select(g => new { CustomerId = g.Key, OrderCount = g.Count() })
            .ToList();
        Console.WriteLine("Thống kê số lượng đơn hàng của từng khách hàng:");
        orderCountByCustomer.ForEach(o => Console.WriteLine($"Customer ID: {o.CustomerId}, Order Count: {o.OrderCount}"));

        // 7. Tìm các khách hàng không có đơn hàng
        var customersWithoutOrders = customers
            .Where(c => !orders.Any(o => o.CustomerId == c.CustomerId))
            .ToList();
        Console.WriteLine("Khách hàng không có đơn hàng:");
        customersWithoutOrders.ForEach(c => Console.WriteLine(c.CustomerName));

        // 8. Lấy danh sách đơn hàng trong khoảng thời gian
        DateTime startDate = new DateTime(2024, 1, 1);
        DateTime endDate = new DateTime(2024, 12, 31);
        var ordersInRange = orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
        Console.WriteLine("Danh sách đơn hàng trong năm 2024:");
        ordersInRange.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}, Date: {o.OrderDate}"));

        // 9. Sắp xếp danh sách khách hàng theo tổng giá trị đơn hàng giảm dần
        var sortedCustomersByOrders = customers
            .OrderByDescending(c => orders.Count(o => o.CustomerId == c.CustomerId))
            .ToList();
        Console.WriteLine("Danh sách khách hàng sắp xếp theo số lượng đơn hàng:");
        sortedCustomersByOrders.ForEach(c => Console.WriteLine(c.CustomerName));

        // 10. Tìm khách hàng đặt hàng gần đây nhất
        var latestOrder = orders
            .OrderByDescending(o => o.OrderDate)
            .FirstOrDefault();

        if (latestOrder != null)
        {
            var recentCustomer = customers
                .FirstOrDefault(c => c.CustomerId == latestOrder.CustomerId);

            if (recentCustomer != null)
            {
                Console.WriteLine($"Khách hàng đặt hàng gần đây nhất: {recentCustomer.CustomerName}, Ngày đặt: {latestOrder.OrderDate}");
            }
        }
        else
        {
            Console.WriteLine("Không có đơn hàng nào trong hệ thống.");
        }

    }
}
