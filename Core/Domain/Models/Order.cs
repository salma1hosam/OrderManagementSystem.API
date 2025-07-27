using Domain.Models.Enums;

namespace Domain.Models
{
    public class Order : BaseEntity<Guid>
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int CustomerId { get; set; } //FK
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        public Invoice? Invoice { get; set; }
    }
}
