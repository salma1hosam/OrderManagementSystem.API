namespace Shared.DataTransferObjects.OrderDtos
{
    public class CreateOrderDto
    {
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<CreateOrderItemDto> OrderItems { get; set; } = [];
    }
}
