using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects.InvoicDtos;

namespace Services.MappingProfiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDetailsDto>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Order.OrderItems));

            CreateMap<OrderItem, InvoiceOrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Invoice, InvoiceDto>();
        }
    }
}
