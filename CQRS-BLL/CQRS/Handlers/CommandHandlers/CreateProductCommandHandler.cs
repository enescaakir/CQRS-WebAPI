using CQRS_BLL.CQRS.Commands.Requests;
using CQRS_BLL.CQRS.Commands.Responses;
using CQRS_DAL.Repositories.Abstract;
using MediatR;

namespace CQRS_BLL.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductCommandRepository _productRepository;

        public CreateProductCommandHandler(IProductCommandRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = _productRepository.InsertProduct(new()
            {
                Name = request.Name,
                Category = request.Category,
                Price = request.Price,
                IsActive = request.IsActive,
                CreationTime = request.CreationTime
            });

            if (data == null)
                return new CreateProductCommandResponse();

            return new CreateProductCommandResponse() { IsSucceed = true, ProductId = data.Id };
        }
    }
}
