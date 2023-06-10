using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }


        [BsonElement("category")]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }


        [BsonElement("brand")]
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }


        [BsonElement("model")]
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }


        [BsonElement("color")]
        public string Color { get; set; }

    }
}
