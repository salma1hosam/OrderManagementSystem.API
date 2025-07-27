using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Repository.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null);

    }
}
