using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Repository.Contracts;
using Services.Abstractions;
using Shared.DataTransferObjects.OrderDtos;

namespace Services
{
    public class OrderService(IUnitOfWork _unitOfWork, IMapper _mapper) : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            //Get Customer
            var customer = _unitOfWork.CustomerRepository.Get(C => C.Email == createOrderDto.Email).Result.FirstOrDefault()
                ?? throw new CustomerNotFoundException();

            //Create OrderItem List
            List<OrderItem> orderItems = [];
            foreach (var item in createOrderDto.OrderItems)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId)
                    ?? throw new ProductNotFoundException(item.ProductId);

                if (product.Stock < item.Quantity)
                    throw new BadRequestException($"Insufficient stock for {product.Name}");

                var orderItem = new OrderItem()
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                orderItems.Add(orderItem);

                product.Stock -= item.Quantity;
                _unitOfWork.ProductRepository.Update(product);
            }

            //Calculate the Order Total Amount and Discount
            var totalAmount = orderItems.Sum(item => item.UnitPrice * item.Quantity);

            foreach (var item in orderItems)
                item.Discount = item.UnitPrice * GetDiscount(totalAmount);

            //Create Order object
            var order = new Order()
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now,
                PaymentMethod = Enum.Parse<PaymentMethod>(createOrderDto.PaymentMethod),
                Status = OrderStatus.Pending,
                OrderItems = orderItems,
                TotalAmount = totalAmount * (1 - GetDiscount(totalAmount))
            };

            await _unitOfWork.OrderRepository.CreateAsync(order);

            //Generate Invoice
            var invoice = new Invoice()
            {
                OrderId = order.Id,
                InvoiceDate = DateTime.Now,
                TotalAmount = order.TotalAmount,
            };

            await _unitOfWork.InvoiceRepository.CreateAsync(invoice);
            order.Invoice = invoice;

            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Failed to Create the Order");

            return _mapper.Map<Order, OrderToReturnDto>(order);
        }

        private decimal GetDiscount(decimal orderTotalAmount)
        {
            decimal discount = 0m;

            if (orderTotalAmount > 200)
                discount = 0.10m;
            else if (orderTotalAmount > 100)
                discount = 0.5m;

            return discount;
        }

        public async Task<OrderDetailsDto> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderDetailsAsync(orderId) 
                ?? throw new OrderNotFoundException($"Order with id = {orderId} is Not Found");
            return _mapper.Map<Order ,  OrderDetailsDto>(order);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllOrdersAsync();
            if (!orders.Any()) throw new OrderNotFoundException("No Orders Found");
            return _mapper.Map<IEnumerable<Order> , IEnumerable<OrderToReturnDto>>(orders);
        }
    }
}
