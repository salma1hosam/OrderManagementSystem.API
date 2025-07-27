using Shared.DataTransferObjects.OrderDtos;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDetailsDto> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync();
        Task<UpdatedOrderStatusDto> UpdateStatusAsync(Guid orderId , OrderStatusDto orderStatusDto);
    }
}
