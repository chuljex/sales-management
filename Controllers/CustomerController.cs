using SalesManagement.Models;
using System.Linq;
using SalesManagement.Data;
using SalesManagement.services;
using ConsoleTables;

namespace SalesManagement.Controllers
{
    public class CustomerController
    {
        private SalesContext _context;

        public CustomerController(SalesContext context) => _context = context;
        private readonly UpdateRecord _updateRecord = new UpdateRecord();

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
            Console.WriteLine("Thêm khách hàng thành công!");
        }

        public void Update(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            if (customer != null)
            {
                var customerIndex = _context.Customers.IndexOf(customer);
                if (customerIndex != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LƯU Ý: BỎ TRỐNG ĐỂ GIỮ GIÁ TRỊ CŨ");
                    Console.ResetColor();
                    List<string> dataField = ["tên", "email", "số điện thoại", "địa chỉ"];
                    List<string> dataType = ["string", "string", "string", "string"];
                    var updatedData = _updateRecord.Update("khách hàng", dataField, dataType);
                    if (updatedData[0].Length < 1)
                    {
                        updatedData[0] = customer.CustomerName;
                    }
                    if (updatedData[1].Length < 1)
                    {
                        updatedData[1] = customer.Email;
                    }

                    if (updatedData[2].Length < 1)
                    {
                        updatedData[2] = customer.PhoneNumber;
                    }
                    if (updatedData[3].Length < 1)
                    {
                        updatedData[3] = customer.Address;
                    }
                    var updatedCustomer = new Customer { CustomerId = id, CustomerName = updatedData[0], Email = updatedData[1], PhoneNumber = updatedData[2], Address = updatedData[3] };
                    _context.Customers[customerIndex] = updatedCustomer;
                }
                Console.WriteLine("Cập nhật khách hàng thành công!");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy khách hàng với id: {id}");
            }
        }

        public Customer GetCustomerById(int customerId) =>
            _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
    }
}
