using Domain.Models;
using Domain.Repository.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class CustomerRepository(OrderManagementDbContext _dbContext) : GenericRepository<Customer , int>(_dbContext) , ICustomerRepository
    {
    }
}
