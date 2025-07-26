using Shared.DataTransferObjects.ProductDtos;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDetailsDto> GetProductDetailsAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
