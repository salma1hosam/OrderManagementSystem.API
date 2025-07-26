using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity , TKey> GetRepository<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> SaveChangesAsync();
    }
}
