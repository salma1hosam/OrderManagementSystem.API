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
    }
}
