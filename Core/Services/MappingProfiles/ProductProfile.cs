using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects.ProductDtos;

namespace Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product , ProductDto>();
        }
    }
}
