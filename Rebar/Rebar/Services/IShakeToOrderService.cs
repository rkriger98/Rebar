using Rebar.Models;

namespace Rebar.Services
{
    public interface IShakeToOrderService
    {
        Task<IEnumerable<ShakeToOrder>> GetAllAsyc();
        Task<ShakeToOrder> GetById(Guid id);
        Task CreateAsync(ShakeToOrder shakeToOrder);
    }
}
