using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Categories
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }


        [BsonElement("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [BsonElement("description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
