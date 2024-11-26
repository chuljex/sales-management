using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;
using ConsoleTables;

namespace SalesManagement.Controllers
{
    public class CustomerController
    {
        private SalesContext _context;

        public CustomerController(SalesContext context) => _context = context;

        public IEnumerable<Customer> GetAllCustomers() => _context.Customers;
        public void DisplayAllItems()
        {
            DisplayCustomer(_context.Customers);
        }

        public void DisplayCustomer(List<Customer> customers)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = ["Mã", "Tên Khách Hàng", "Email", "Số Điện Thoại", "Địa Chỉ"],
                EnableCount = false
            });

            foreach (var customer in customers)
            {
                table.AddRow(customer.CustomerId, customer.CustomerName, customer.Email, customer.PhoneNumber, customer.Address);
            }

            table.Write();
        }

        public void Add(Customer customer)
        {
            var id = _context.Customers[_context.Customers.Count - 1].CustomerId + 1;
            customer.CustomerId = id;
            _context.Customers.Add(customer);
        }

        public Customer GetCustomerById(int customerId) =>
            _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
    }
}
