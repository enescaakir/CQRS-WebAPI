using MongoDB.Driver;

namespace CQRS_DAL
{
    public class AppQueryDbContext
    {
        public readonly MongoClient mongoClient;

        public AppQueryDbContext()
        {
            mongoClient = new MongoClient("mongodb://admin:enes123@mongodb:27017/");
        }
    }
}
