using Domain.Models;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey>(OrderManagementDbContext _dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task CreateAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();
        public async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> Get<TEntity, TProperty>(Expression<Func<TEntity, bool>> predicate = null,
                                                           Expression<Func<TEntity, TProperty>> navigationPropertyPath = null) where TEntity : BaseEntity<TKey>
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (navigationPropertyPath is not null)
                query = query.Include(navigationPropertyPath);

            if (predicate is not null)
                query = query.Where(predicate);

            return query;
        }


        public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    }
}
