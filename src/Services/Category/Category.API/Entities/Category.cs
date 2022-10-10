using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Category.API.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Namw { get; set; }
        public string Description { get; set; }
    }
}
