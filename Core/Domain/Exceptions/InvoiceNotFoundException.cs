namespace Domain.Exceptions
{
    public sealed class InvoiceNotFoundException(string message) : NotFoundException(message)
    {
    }
}
