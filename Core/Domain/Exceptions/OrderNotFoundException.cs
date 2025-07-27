namespace Domain.Exceptions
{
    public sealed class OrderNotFoundException(string message) : NotFoundException(message)
    {
    }
}
