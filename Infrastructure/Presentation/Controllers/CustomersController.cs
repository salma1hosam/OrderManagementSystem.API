using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects.CustomerDtos;

namespace Presentation.Controllers
{
    public class CustomersController(ICustomerService _customerService) : ApiBaseController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var result = await _customerService.CreateCustomerAsync(createCustomerDto);
            return Ok(result);
        }

        [HttpGet("{customerId}/orders")]
        public async Task<ActionResult<IEnumerable<CustomerOrderDto>>> GetAllCustomerOrders(int customerId)
        {
            var result = await _customerService.GetAllCustomerOrdersAsync(customerId);
            return Ok(result);
        }
    }
}
