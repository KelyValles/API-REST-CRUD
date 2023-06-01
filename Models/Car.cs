using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }


        [BsonElement("category")]
        public string Category { get; set; }


        [BsonElement("brand")]
        public string Brand { get; set; }


        [BsonElement("model")]
        public string Model { get; set; }

    }
}
