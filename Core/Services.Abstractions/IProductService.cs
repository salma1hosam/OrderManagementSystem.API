using Shared.DataTransferObjects.ProductDtos;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    }
}
