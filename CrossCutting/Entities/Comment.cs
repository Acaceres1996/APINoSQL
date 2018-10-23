using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public class Comment
    {
        [BsonId]
        public Guid Id { get; set; }
        public User Owner { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
