using CQRS_BLL.CQRS.Queries.Requests;
using CQRS_BLL.CQRS.Queries.Responses;
using CQRS_DAL.Repositories.Abstract;
using MediatR;

namespace CQRS_BLL.CQRS.Handlers.QueryHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<GetProductsQueryResponse>>
    {
        private readonly IProductQueryRepository _productRepository;

        public GetProductsQueryHandler(IProductQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetProductsQueryResponse>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
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
