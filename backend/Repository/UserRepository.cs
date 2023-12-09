using backend.Models;
using backend.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Repository;

public class UserRepository
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(
        IOptions<MongoSettings> MongoSettings)
    {
        var mongoClient = new MongoClient(
            MongoSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MongoSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            MongoSettings.Value.UsersCollectionName);
    }

    public async Task<List<User>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
        await _usersCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);
        

    public async Task UpdateAsync(string id, User updatedBook) =>
        await _usersCollection.ReplaceOneAsync(x => x._id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x._id == id);
}

