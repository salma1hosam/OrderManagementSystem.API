namespace Shared.DataTransferObjects.OrderDtos
{
    public class OrderDetailsDto
    {
        public string Email { get; set; }
        public DateTime OrderDate { get; set; } 
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<OrderItemToReturnDto> OrderItems { get; set; } = [];
        public OrderInvoiceDto Invoice { get; set; }
    }
}
