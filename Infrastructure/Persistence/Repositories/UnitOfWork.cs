using Domain.Models;
using Domain.Repository.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _dbContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IInvoiceRepository> _invoiceRepository;

        public UnitOfWork(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
            _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(dbContext));
        }
        public IProductRepository ProductRepository => _productRepository.Value;

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IOrderRepository OrderRepository => _orderRepository.Value;

        public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;

        //private readonly Dictionary<string, object> _repositories = [];
        //public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        //{
        //    var typeName = typeof(TEntity).Name;
        //    if (_repositories.TryGetValue(typeName, out object? value))
        //        return (IGenericRepository<TEntity, TKey>)value;
        //    else
        //    {
        //        var repository = new GenericRepository<TEntity, TKey>(_dbContext);
        //        _repositories.Add(typeName, repository);
        //        return repository;
        //    }
        //}

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
