using DataAccessLayer.Interfaces;
using MongoDB.Driver;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementations
{
    public class DALCommentsMongo : IDALComments
    {
        public void AddComment(Comment u)
        {         
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<Comment>("Comments");
            collection.InsertOne(u);
        }

        public void addSecondComment(string guid, Comment c)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<Comment>("Comments");
            var filter = Builders<Comment>.Filter.Eq("Id", guid);
            Comment root = collection.Find(filter).First();
            root.Comments.Add(c);
            collection.FindOneAndReplace(filter, root);
        }

        public Comment getCommentByGUID(string guid)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<Comment>("Comments");
            var filter = Builders<Comment>.Filter.Eq("Id", guid);
            Comment root = collection.Find(filter).First();
            return root;
        }

        public List<Comment> GetCommentsByEmail(string email)
        {
            IDALUsers users = new DALUsersMongo();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<Comment>("Comments");
            var filter = Builders<Comment>.Filter.Eq("Owner", users.getUser(email) );
            List<Comment> results = collection.Find(filter).ToList();
            return results;
        }
    }
}
