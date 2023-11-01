using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsyc();
        Task<Order> GetById(Guid id);
        Task CreateAsync(Order order);
    }
}
