using Shared.DataTransferObjects.CustomerDtos;

namespace Services.Abstractions
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task<IEnumerable<CustomerOrderDto>> GetAllCustomerOrdersAsync(int customerId);
    }
}
