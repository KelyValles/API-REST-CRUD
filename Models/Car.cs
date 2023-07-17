﻿using MongoDB.Bson;
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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Category must be between 2 and 50 characters long")]
        public string Category { get; set; }


        [BsonElement("brand")]
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }


        [BsonElement("model")]
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }


        [BsonElement("color")]
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }

        

        [BsonElement("enginetype")]
        [Required(ErrorMessage = "EngineType is required")]
        public string EngineType { get; set; }

    }
}
