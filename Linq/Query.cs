using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagement.Data;
using SalesManagement.Models;

namespace SalesManagement.Linq
{
    public class LinqQueries
    {
        private readonly SalesContext _context;

        public LinqQueries(SalesContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public dynamic GetTopCustomerByOrders()
        {
            return _context.Orders
                .GroupBy(o => o.CustomerId)
                .OrderByDescending(g => g.Count())
                .Select(g => new { CustomerId = g.Key, OrderCount = g.Count() })
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetOrdersByStatus(string status)
        {
            return _context.Orders.Where(o => o.Status == status).ToList();
        }

        public IEnumerable<dynamic> GetCustomerOrderReport()
        {
            return _context.Customers.Join(
                _context.Orders,
                c => c.CustomerId,
                o => o.CustomerId,
                (c, o) => new { c.CustomerName, o.OrderId, o.OrderDate, o.Status }
            ).ToList();
        }

        public IEnumerable<dynamic> GetOrderCountsByCustomer()
        {
            return _context.Orders.GroupBy(o => o.CustomerId)
                .Select(g => new { CustomerId = g.Key, OrderCount = g.Count() })
                .ToList();
        }

        public IEnumerable<Customer> GetCustomersWithoutOrders()
        {
            return _context.Customers
                .Where(c => !_context.Orders.Any(o => o.CustomerId == c.CustomerId))
                .ToList();
        }

        public IEnumerable<Order> GetOrdersInDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToList();
        }

        public IEnumerable<Customer> GetSortedCustomersByOrders()
        {
            return _context.Customers
                .OrderByDescending(c => _context.Orders.Count(o => o.CustomerId == c.CustomerId))
                .ToList();
        }

        public dynamic GetLatestOrderWithCustomer()
        {
            var latestOrder = _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefault();

            if (latestOrder != null)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == latestOrder.CustomerId);
                return new { CustomerName = customer?.CustomerName, latestOrder.OrderDate };
            }

            return null;
        }
    }
}
