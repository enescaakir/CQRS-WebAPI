using CQRS_BLL.CQRS.Queries.Responses;
using MediatR;

namespace CQRS_BLL.CQRS.Queries.Requests
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
