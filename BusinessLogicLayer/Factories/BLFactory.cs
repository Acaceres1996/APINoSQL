using BusinessLogicLayer.Implementations;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Factories
{
    public class BLFactory
    {
        public static IBLUsers GetBLUsers() {
            return new BLUsers();
        }

        public static IBLComments GetBLComments() {
            return new BLComments();
        }
    }
}
