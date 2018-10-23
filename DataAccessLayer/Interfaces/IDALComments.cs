using Shared.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDALComments
    {
        void AddComment(Comment u);
        List<Comment> GetCommentsByEmail(string email);
        void addSecondComment(string guid, Comment c);
        Comment getCommentByGUID(string guid);
    }
}
