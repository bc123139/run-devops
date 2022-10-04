using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shopping.API.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageFile { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
