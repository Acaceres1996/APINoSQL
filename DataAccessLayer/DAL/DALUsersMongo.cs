using DataAccessLayer.Interfaces;
using MongoDB.Driver;
using Shared.Entities;
using System.Linq;

namespace DataAccessLayer.Implementations
{
    public class DALUsersMongo : IDALUsers
    {
        public void AddUser(User u)
        {         
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(u);
        }

        public User getUser(string email)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<User>("Users");
            var filter = Builders<User>.Filter.Eq("Email", email);
            User u = collection.Find(filter).First();
            return u;
        }
    }
}
