using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.CustomerDtos
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
