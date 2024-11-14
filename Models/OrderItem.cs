namespace SalesManagement.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }  // Khóa ngoại đến Order
        public Order Order { get; set; }
        public int ProductId { get; set; }  // Khóa ngoại đến Product
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
