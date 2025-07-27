using Domain.Models;
using Domain.Repository.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class InvoiceRepository(OrderManagementDbContext _dbContext) : GenericRepository<Invoice , Guid>(_dbContext) ,  IInvoiceRepository
    {
    }
}
