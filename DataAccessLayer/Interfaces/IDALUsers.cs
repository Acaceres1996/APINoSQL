using Shared.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IDALUsers
    {
        void AddUser(User u);
        User getUser(string email);
    }
}
