using CQRS_BLL.CQRS.Commands.Responses;
using MediatR;

namespace CQRS_BLL.CQRS.Commands.Requests
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
