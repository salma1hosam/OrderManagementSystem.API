using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IUnitOfWork
    {
        //IGenericRepository<TEntity , TKey> GetRepository<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
        IProductRepository ProductRepository { get;}
        ICustomerRepository CustomerRepository { get;}
        IOrderRepository OrderRepository { get;}
        IInvoiceRepository InvoiceRepository { get;}
        Task<int> SaveChangesAsync();
    }
}
