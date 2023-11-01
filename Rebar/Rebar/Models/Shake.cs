using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Rebar.Models;
using MongoDB.Driver;

namespace Rebar.Models
{
    public enum Sizes
    {
        Small, Medium, Large
    }
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid ShakeID { get; private set; } = Guid.NewGuid();
        public string? ShakeName { get; set; }
        public string? Description { get; set; }
        public double Small { get; set; }
        public double Medium { get; set; }
        public double Large { get; set; }
        private static IMongoCollection<Shake>? Shakes { get; }
        public double GetPriceBySize(Sizes size)
        {
            double returnValue = 0;
            if (size == Sizes.Small)
                returnValue = Small;
            if (size == Sizes.Medium)
                returnValue = Medium;
            if (size == Sizes.Large)
                returnValue = Large;
            return returnValue;
        }

    }
}