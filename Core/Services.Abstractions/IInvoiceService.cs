using Shared.DataTransferObjects.InvoicDtos;

namespace Services.Abstractions
{
    public interface IInvoiceService
    {
        Task<InvoiceDetailsDto> GetInvoiceDetailsAsync(Guid invoiceId);
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
    }
}
