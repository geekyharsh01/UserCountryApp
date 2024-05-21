// Necessary namespaces for MongoDB and data annotations
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UserCountryApp.Models
{
    // This class represents a User in the UserCountryApp application
    public class User
    {
        // BsonId attribute marks this property as the primary key in the MongoDB collection
        // BsonRepresentation attribute specifies the data type in MongoDB, here it's an ObjectId
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // Property to hold the unique identifier for the User object, initialized to an empty string
        public string Id { get; set; } = string.Empty;

        // BsonElement attribute maps this property to the "Name" field in the MongoDB document
        [BsonElement("Name")]
        // Property to hold the name of the User, initialized to an empty string
        public string Name { get; set; } = string.Empty;

        // BsonElement attribute maps this property to the "Country" field in the MongoDB document
        [BsonElement("Country")]
        // Property to hold the country of the User, initialized to an empty string
        public string Country { get; set; } = string.Empty;
    }
}
