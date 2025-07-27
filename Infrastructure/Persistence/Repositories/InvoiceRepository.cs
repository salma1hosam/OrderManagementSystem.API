using Domain.Models;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class InvoiceRepository(OrderManagementDbContext _dbContext) : GenericRepository<Invoice, Guid>(_dbContext), IInvoiceRepository
    {
        public async Task<Invoice> GetInvoiceDetailsAsync(Guid invoiceId)
        {
            return await _dbContext.Invoices.Include(I => I.Order)
                                            .ThenInclude(O => O.OrderItems)
                                            .ThenInclude(OI => OI.Product)
                                            .FirstOrDefaultAsync(I => I.Id == invoiceId);
        }
    }
}
