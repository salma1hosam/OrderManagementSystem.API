using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Repository.Contracts;
using Services.Abstractions;
using Shared.DataTransferObjects.CustomerDtos;

namespace Services
{
    public class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerService
    {
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer()
            {
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
            };
            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Failed to Create Customer");
            return new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            };
        }

        public async Task<IEnumerable<CustomerOrderDto>> GetAllCustomerOrdersAsync(int customerId)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(customerId)
                ?? throw new CustomerNotFoundException();

            var orders = await _unitOfWork.OrderRepository.GetAllOrdersByCustomerIdAsync(customerId);
            if (!orders.Any()) throw new OrderNotFoundException("No Orders Found");

            return _mapper.Map<IEnumerable<Order>, IEnumerable<CustomerOrderDto>>(orders);
        }
    }
}
