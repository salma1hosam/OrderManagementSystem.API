using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.OrderDtos
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        
        [Range(1,200)]
        public int Quantity { get; set; }
    }
}
