using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects.OrderDtos;

namespace Presentation.Controllers
{
    public class OrdersController(IOrderService _orderService) : ApiBaseController
    {
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var result = await _orderService.CreateOrderAsync(createOrderDto);
            return Ok(result);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetails(Guid orderId)
        {
            var result = await _orderService.GetOrderDetailsAsync(orderId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(result);
        }

        [HttpPut("{orderId}/status")]
        public async Task<ActionResult<UpdatedOrderStatusDto>> UpdatteStatus(Guid orderId , OrderStatusDto orderStatusDto)
        {
            var result = await _orderService.UpdateStatusAsync(orderId , orderStatusDto);
            return Ok(result);
        }
    }
}
