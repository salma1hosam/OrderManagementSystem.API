using AutoMapper;
using Domain.Models;
using Domain.Repository.Contracts;
using Services.Abstractions;
using Shared.DataTransferObjects.ProductDtos;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<CreateProductDto, Product>(createProductDto);
            await _unitOfWork.GetRepository<Product, int>().CreateAsync(product);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Product Is Not Created");
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
