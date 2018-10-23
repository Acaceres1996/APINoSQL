using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Factories
{
    public class DALFactory
    {
        public static IDALUsers getDALUsers() {
            return new DALUsersMongo();
        }

        public static IDALComments getDALComments() {
            return new DALCommentsMongo();
        }
    }
}
