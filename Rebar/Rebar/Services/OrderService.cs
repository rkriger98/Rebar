using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderService(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _orderCollection = mongoDatabase.GetCollection<Order>
                (dbSettings.Value.OrdersCollectionName);
        }

        public async Task CreateAsync(Order order) =>
            await _orderCollection.InsertOneAsync(order);

        public async Task<IEnumerable<Order>> GetAllAsyc() =>
            await _orderCollection.Find(_ => true).ToListAsync();

        public async Task<Order> GetById(Guid id) =>
            await _orderCollection.Find(a => a.OrderID == id).FirstOrDefaultAsync();
        
    }
}
