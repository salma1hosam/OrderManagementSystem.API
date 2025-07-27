using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.CustomerDtos
{
    public class CreateCustomerDto
    {
        [MinLength(3 , ErrorMessage = "Name field should be more than 3 characters")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
