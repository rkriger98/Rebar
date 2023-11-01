using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Drawing;
using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Models
{
    public class ShakeToOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid ShakeID { get; set; }
        public Sizes Sizes { get; set; }
        public double Price {  get; set; }
    }
}