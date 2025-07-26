using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects.ProductDtos;

namespace Presentation.Controllers
{
    public class ProductsController(IProductService _productService) : ApiBaseController
    {
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
    }
}
