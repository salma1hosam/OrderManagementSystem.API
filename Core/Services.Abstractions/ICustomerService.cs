using Shared.DataTransferObjects.CustomerDtos;

namespace Services.Abstractions
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
    }
}
