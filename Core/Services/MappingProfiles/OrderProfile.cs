using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects.OrderDtos;

namespace Services.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(distination => distination.Email, option => option.MapFrom(src => src.Customer.Email));
            CreateMap<OrderItem, OrderItemToReturnDto>()
                .ForMember(distination => distination.ProductName, option => option.MapFrom(src => src.Product.Name));
        }
    }
}
