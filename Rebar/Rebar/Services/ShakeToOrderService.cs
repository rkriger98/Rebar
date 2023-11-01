using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class ShakeToOrderService : IShakeToOrderService
    {
        private readonly IMongoCollection<ShakeToOrder> _shakeToOrderCollection;

        public ShakeToOrderService(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shakeToOrderCollection = mongoDatabase.GetCollection<ShakeToOrder>
                (dbSettings.Value.ShakesCollectionName);
        }

        public async Task CreateAsync(ShakeToOrder shakeToOrder) =>
            await _shakeToOrderCollection.InsertOneAsync(shakeToOrder);

        public async Task<IEnumerable<ShakeToOrder>> GetAllAsyc() =>
            await _shakeToOrderCollection.Find(_ => true).ToListAsync();

        public async Task<ShakeToOrder> GetById(Guid id) =>
            await _shakeToOrderCollection.Find(a => a.ShakeID == id).FirstOrDefaultAsync();
    }
}
