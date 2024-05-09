using CQRS_BLL.CQRS.Queries.Responses;
using MediatR;

namespace CQRS_BLL.CQRS.Queries.Requests
{
    public class GetProductsQueryRequest : IRequest<List<GetProductsQueryResponse>>
    {
    }
}
