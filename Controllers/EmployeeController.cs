using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;

namespace SalesManagement.Controllers
{
    public class EmployeeController
    {
        private SalesContext _context;

        public EmployeeController(SalesContext context) => _context = context;

        public IEnumerable<Employee> GetAllEmployees() => _context.Employees;

        public Employee GetEmployeeById(int employeeId) =>
            _context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
    }
}
