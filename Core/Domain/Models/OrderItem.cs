namespace Domain.Models
{
    public class OrderItem : BaseEntity<int>
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public Guid OrderId { get; set; } //FK
        public Order Order { get; set; }
        public int ProductId { get; set; } //FK
        public Product Product { get; set; }
    }
}
