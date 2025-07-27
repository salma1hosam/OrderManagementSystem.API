using Shared.DataTransferObjects.OrderDtos;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(CreateOrderDto createOrderDto);
    }
}
