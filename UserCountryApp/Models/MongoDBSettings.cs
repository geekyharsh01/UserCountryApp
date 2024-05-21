// Namespace declaration for the MongoDB settings class, residing in the Models namespace
namespace UserCountryApp.Models
{
    // Class that represents MongoDB configuration settings for the UserCountryApp application
    public class MongoDBSettings
    {
        // Property to hold the MongoDB connection string, initialized to null
        public string ConnectionString { get; set; } = null!;

        // Property to hold the name of the MongoDB database, initialized to null
        public string DatabaseName { get; set; } = null!;

        // Property to hold the name of the MongoDB collection, initialized to null
        public string CollectionName { get; set; } = null!;
    }
}
