using Rebar.Models;

namespace Rebar.Services
{
    public interface IShakeService
    {
        Task<IEnumerable<Shake>> GetAllAsyc();
        Task<Shake> GetById(Guid id);
        Task CreateAsync(Shake shake);
    }
}
