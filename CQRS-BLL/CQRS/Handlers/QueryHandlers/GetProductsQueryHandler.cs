using CQRS_BLL.CQRS.Queries.Requests;
using CQRS_BLL.CQRS.Queries.Responses;
using CQRS_DAL.Repositories.Abstract;

namespace CQRS_BLL.CQRS.Handlers.QueryHandlers
{
    public class GetProductsQueryHandler
    {
        private readonly IProductQueryRepository _productRepository;

        public GetProductsQueryHandler(IProductQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<GetProductsQueryResponse> GetProducts(GetProductsQueryRequest request)
        {
            return _productRepository.GetProducts()
                    .Select(d => new GetProductsQueryResponse
                    {
                        Id = d.ProductId,
                        Name = d.Name,
                        Category = d.Category,
                        Price = d.Price,
                        IsActive = d.IsActive,
                        CreationTime = d.CreationTime
                    }).ToList();
        }
    }
}
