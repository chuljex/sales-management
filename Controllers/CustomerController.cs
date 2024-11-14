using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;

namespace SalesManagement.Controllers
{
    public class CustomerController
    {
        private SalesContext _context;

        public CustomerController(SalesContext context) => _context = context;

        public IEnumerable<Customer> GetAllCustomers() => _context.Customers;

        public Customer GetCustomerById(int customerId) =>
            _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
    }
}
