using Domain.Exceptions;
using Domain.Models;
using Domain.Repository.Contracts;
using Services.Abstractions;
using Shared.DataTransferObjects.CustomerDtos;

namespace Services
{
    public class CustomerService(IUnitOfWork _unitOfWork) : ICustomerService
    {
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer()
            {
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
            };
            await _unitOfWork.GetRepository<Customer, int>().CreateAsync(customer);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Customer Is Not Created");
            return new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            };
        }
    }
}
