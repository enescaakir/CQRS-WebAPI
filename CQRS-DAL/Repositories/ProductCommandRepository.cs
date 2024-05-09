using CQRS_DAL.Entities;
using CQRS_DAL.Repositories.Abstract;

namespace CQRS_DAL.Repositories
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private AppCommandDbContext _context;

        public ProductCommandRepository(AppCommandDbContext context)
        {
            _context = context;
        }

        public Product InsertProduct(Product product)
        {
            var result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return null;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
    }
}
