using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Factories;
using DataAccessLayer.Interfaces;
using Shared.Entities;

namespace BusinessLogicLayer.Implementations
{
    public class BLUsers : IBLUsers
    {
       private IDALUsers _dal;

        public BLUsers()
        {
            _dal = DALFactory.getDALUsers();
        }

        public void AddUser(User u)
        {
            _dal.AddUser(u);
        }

        public User getUser(string email)
        {
            return _dal.getUser(email);
        }
    }
}
