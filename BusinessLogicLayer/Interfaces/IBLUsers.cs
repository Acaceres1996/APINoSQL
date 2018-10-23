using Shared.Entities;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBLUsers
    {
        void AddUser(User u);

        User getUser(string email);
    }
}
