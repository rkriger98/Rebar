using MongoDB.Driver;

namespace Rebar.Models
{
    public class DatabaseSettings
    {
        private readonly IMongoDatabase? _database;
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? ShakesCollectionName { get; set; }
        public string? OrdersCollectionName { get; set; }
        public string? ShakesToOrderCollectionName { get; set; }
    }
}