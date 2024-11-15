namespace SalesManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        // Khóa ngoại đến Shop
        public int ShopId { get; set; }
    }
}
