using CQRS_BLL.CQRS.Commands.Requests;
using CQRS_BLL.CQRS.Commands.Responses;
using CQRS_DAL.Repositories.Abstract;
using MediatR;

namespace CQRS_BLL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductCommandRepository _productRepository;

        public DeleteProductCommandHandler(IProductCommandRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = _productRepository.DeleteProduct(request.Id);
            if (data == null)
                return new DeleteProductCommandResponse();

            return new DeleteProductCommandResponse { IsSuccess = true };
        }
    }
}
