using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Factories;
using DataAccessLayer.Interfaces;
using Shared.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer.Implementations
{
    public class BLComments : IBLComments
    {
       private IDALComments _dal;

        public BLComments()
        {
            _dal = DALFactory.getDALComments();
        }

        public void AddComment(Comment u)
        {
            _dal.AddComment(u);
        }

        public void addSecondComment(string guid, Comment c)
        {
            _dal.addSecondComment(guid, c);
        }

        public Comment GetCommentByGUID(string guid)
        {
            return _dal.getCommentByGUID(guid);
        }

        public List<Comment> GetCommentsByEmail(string email)
        {
            return _dal.GetCommentsByEmail(email);
        }
    }
}
