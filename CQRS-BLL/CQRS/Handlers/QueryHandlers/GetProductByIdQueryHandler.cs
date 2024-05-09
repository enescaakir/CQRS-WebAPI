using CQRS_BLL.CQRS.Queries.Requests;
using CQRS_BLL.CQRS.Queries.Responses;
using CQRS_DAL.Repositories.Abstract;

namespace CQRS_BLL.CQRS.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IProductQueryRepository _productRepository;

        public GetProductByIdQueryHandler(IProductQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public GetProductByIdQueryResponse GetProductById(GetProductByIdQueryRequest request)
        {
            var data = _productRepository.GetProductById(request.Id);
            if (data == null)
                return null;

            return new GetProductByIdQueryResponse
            {
                Id = data.ProductId,
                Name = data.Name,
                Category = data.Category,
                Price = data.Price,
                IsActive = data.IsActive,
                CreationTime = data.CreationTime
            };
        }
    }
}
