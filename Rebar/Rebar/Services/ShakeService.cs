using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Services
{
    public class ShakeService : IShakeService
    {
        private readonly IMongoCollection<Shake> _shakeCollection;

        public ShakeService(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shakeCollection = mongoDatabase.GetCollection<Shake>
                (dbSettings.Value.ShakesCollectionName);
        }

        public async Task CreateAsync(Shake shake) =>
            await _shakeCollection.InsertOneAsync(shake);

        public async Task<IEnumerable<Shake>> GetAllAsyc() =>
            await _shakeCollection.Find(_ => true).ToListAsync();

        public async Task<Shake> GetById(Guid id) =>
            await _shakeCollection.Find(a => a.ShakeID == id).FirstOrDefaultAsync();

    }
}
