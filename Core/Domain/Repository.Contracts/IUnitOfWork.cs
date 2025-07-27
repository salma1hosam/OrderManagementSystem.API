using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get;}
        ICustomerRepository CustomerRepository { get;}
        IOrderRepository OrderRepository { get;}
        IInvoiceRepository InvoiceRepository { get;}
        IUserRepository UserRepository { get;}
        Task<int> SaveChangesAsync();
    }
}
