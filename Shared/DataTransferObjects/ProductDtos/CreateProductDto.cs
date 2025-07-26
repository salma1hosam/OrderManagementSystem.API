using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.ProductDtos
{
    public class CreateProductDto
    {
        [MinLength(3, ErrorMessage = "Name Field should be more than 3 characters")]
        public string Name { get; set; }

        [Range(1.0 , double.MaxValue , ErrorMessage = "Invalid Value for Price Field")]
        public decimal Price { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Invalid Value for Stock Field")]
        public int Stock { get; set; }
    }
}
