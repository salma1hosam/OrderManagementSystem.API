using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice , Guid>
    {
    }
}
