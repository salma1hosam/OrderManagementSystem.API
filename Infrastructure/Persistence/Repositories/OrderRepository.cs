using Domain.Models;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class OrderRepository(OrderManagementDbContext _dbContext) : GenericRepository<Order, Guid>(_dbContext), IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.Include(O => O.OrderItems)
                                          .ThenInclude(OI => OI.Product)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByCustomerIdAsync(int custermorId)
        {
            return await _dbContext.Orders.Include(O => O.OrderItems)
                                          .ThenInclude(OI => OI.Product)
                                          .Include(O => O.Customer)
                                          .Where(O => O.CustomerId == custermorId)
                                          .ToListAsync();
        }

        public async Task<Order> GetOrderDetailsAsync(Guid orderId)
        {
            return await _dbContext.Orders.Include(O => O.OrderItems)
                                          .ThenInclude(OI => OI.Product)
                                          .Include(O => O.Customer)
                                          .Include(O => O.Invoice)
                                          .FirstOrDefaultAsync(O => O.Id == orderId);
        }
    }
}
