namespace Domain.Exceptions
{
    public sealed class CustomerNotFoundException() : NotFoundException($"Customer is Not Found")
    {
    }
}
