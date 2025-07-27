namespace Domain.Models
{
    public class Invoice : BaseEntity<Guid>
    {
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public Guid OrderId { get; set; } //FK
        public Order Order { get; set; }
    }
}
