using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    public string name { get; set; } = null!;
    public string email { get; set; } = null!;
    public string phoneNumber { get; set; } = null!;
}

