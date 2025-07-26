namespace Domain.Models
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
    }
}
