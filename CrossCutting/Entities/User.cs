using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Entities
{
    public class User
    {
        [BsonId]
        public string Email { get; set; }        
    }
}
