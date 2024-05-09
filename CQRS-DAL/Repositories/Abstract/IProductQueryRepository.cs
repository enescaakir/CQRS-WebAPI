using CQRS_DAL.Entities.Mongo;

namespace CQRS_DAL.Repositories.Abstract
{
    public interface IProductQueryRepository
    {
        List<ProductMongo> GetProducts();
        ProductMongo GetProductById(int id);
    }
}
