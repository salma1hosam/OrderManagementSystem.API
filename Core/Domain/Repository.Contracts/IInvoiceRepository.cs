using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice , Guid>
    {
        Task<Invoice> GetInvoiceDetailsAsync(Guid invoiceId);
    }
}
