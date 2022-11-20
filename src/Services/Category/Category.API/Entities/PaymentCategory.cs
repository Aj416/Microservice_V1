using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Category.API.Entities
{
    public class PaymentCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
