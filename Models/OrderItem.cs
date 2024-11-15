namespace SalesManagement.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }  // Khóa ngoại đến Order
        public int ProductId { get; set; }  // Khóa ngoại đến Product
        public int Quantity { get; set; }
    }
}
