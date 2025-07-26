namespace Domain.Models
{
    public class User : BaseEntity<string>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
