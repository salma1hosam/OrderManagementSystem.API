namespace Shared.DataTransferObjects.CustomerDtos
{
    public class CustomerOrderDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<CustomerOrderItemDto> OrderItems { get; set; } = [];
    }
}
