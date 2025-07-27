using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IUserRepository : IGenericRepository<User , int>
    {
    }
}
