using MongoDB.Driver;

namespace CQRS_DAL.Repositories
{
    public class AppQueryDbContext
    {
        public readonly MongoClient mongoClient;

        public AppQueryDbContext()
        {
            mongoClient = new MongoClient("mongodb://admin:enes123@localhost:27017/");
        }
    }
}
