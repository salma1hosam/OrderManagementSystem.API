using Domain.Models;
using Domain.Repository.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class ProductRepository(OrderManagementDbContext _dbContext) : GenericRepository<Product, int>(_dbContext), IProductRepository
    {
    }
}
