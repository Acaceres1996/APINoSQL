using Shared.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBLComments
    {
        void AddComment(Comment u);
        List<Comment> GetCommentsByEmail(string email);
        void addSecondComment(string guid, Comment c);
        Comment GetCommentByGUID(string guid);
    }
}
