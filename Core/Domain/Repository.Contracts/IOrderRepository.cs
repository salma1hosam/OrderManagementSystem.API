using Domain.Models;

namespace Domain.Repository.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order , Guid>
    {
        Task<IEnumerable<Order>> GetAllOrdersByCustomerIdAsync(int custermorId);
        Task<Order> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
