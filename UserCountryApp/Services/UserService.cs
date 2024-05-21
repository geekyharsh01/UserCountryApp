// Import necessary namespaces
using MongoDB.Driver;
using UserCountryApp.Models;
using Microsoft.Extensions.Options;

// Namespace declaration for the UserService class, residing in the Services namespace
namespace UserCountryApp.Services
{
    // Class that provides methods to interact with the MongoDB collection for User objects
    public class UserService
    {
        // Private field to hold the MongoDB collection of User objects
        private readonly IMongoCollection<User> _usersCollection;

        // Constructor that initializes the UserService with MongoDB settings
        public UserService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            // Create a new MongoClient using the provided connection string
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);

            // Get the MongoDB database using the provided database name
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);

            // Get the MongoDB collection of User objects using the provided collection name
            _usersCollection = mongoDatabase.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        }

        // Method to retrieve all users from the MongoDB collection asynchronously
        public async Task<List<User>> GetAllAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        // Method to retrieve a user by ID from the MongoDB collection asynchronously
        public async Task<User> GetAsync(string id) =>
            await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Method to create a new user in the MongoDB collection asynchronously
        public async Task CreateAsync(User newUser) =>
            await _usersCollection.InsertOneAsync(newUser);

        // Method to update an existing user in the MongoDB collection asynchronously
        public async Task UpdateAsync(string id, User updatedUser) =>
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        // Method to remove a user by ID from the MongoDB collection asynchronously
        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}
