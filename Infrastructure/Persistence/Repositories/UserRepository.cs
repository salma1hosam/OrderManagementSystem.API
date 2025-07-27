using Domain.Models;
using Domain.Repository.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UserRepository(OrderManagementDbContext _dbContext) : GenericRepository<User , int>(_dbContext) ,  IUserRepository
    {
    }
}
