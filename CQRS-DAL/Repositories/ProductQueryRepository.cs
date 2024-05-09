using CQRS_DAL.Entities.Mongo;
using CQRS_DAL.Repositories.Abstract;
using MongoDB.Driver;

namespace CQRS_DAL.Repositories
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppQueryDbContext _queryDbContext;
        private readonly IMongoCollection<ProductMongo> _productColletion;

        public ProductQueryRepository(AppQueryDbContext queryDbContext)
        {
            _queryDbContext = queryDbContext;
            _productColletion = _queryDbContext.mongoClient
                                .GetDatabase("CQRS_DB")
                                .GetCollection<ProductMongo>("Products");
        }

        public ProductMongo GetProductById(int id)
        {
            var product = _productColletion.Find(x => x.ProductId == id).FirstOrDefault();
            return product;
        }

        public List<ProductMongo> GetProducts()
        {
            return _productColletion.Find(x => true).ToList();
        }
    }
}
