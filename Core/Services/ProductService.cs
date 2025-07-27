using AutoMapper;
using Domain.Exceptions;
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
            await _unitOfWork.ProductRepository.CreateAsync(product);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Failed to Create the Product");
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Product> , IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDetailsDto> GetProductDetailsAsync(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId) 
                ?? throw new ProductNotFoundException(productId);
            return _mapper.Map<Product , ProductDetailsDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int productId , UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId) 
                ?? throw new ProductNotFoundException(productId);
            _mapper.Map(updateProductDto, product);
            _unitOfWork.ProductRepository.Update(product);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Failed to Update the Product");
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
