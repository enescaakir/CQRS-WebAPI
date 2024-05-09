using CQRS_DAL.Entities;

namespace CQRS_DAL.Repositories.Abstract
{
    public interface IProductCommandRepository
    {
        Product InsertProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int id);
    }
}
