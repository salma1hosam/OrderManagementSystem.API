using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects.ProductDtos;

namespace Presentation.Controllers
{
    public class ProductsController(IProductService _productService) : ApiBaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var result = await _productService.CreateProductAsync(createProductDto);
            return Ok(result);
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<ProductDetailsDto>> GetProductDetails(int productId)
        {
            var result = await _productService.GetProductDetailsAsync(productId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetAllProducts()
        {
            var results = await _productService.GetAllProductsAsync();
            return Ok(results);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{productId:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int productId , UpdateProductDto updateProductDto)
        {
            var result = await _productService.UpdateProductAsync(productId, updateProductDto);
            return Ok(result);
        }
    }
}
