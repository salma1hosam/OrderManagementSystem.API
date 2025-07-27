namespace Shared.DataTransferObjects.OrderDtos
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<OrderItemToReturnDto> OrderItems { get; set; } = [];
    }
}
