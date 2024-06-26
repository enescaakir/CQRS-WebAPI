﻿using CQRS_BLL.CQRS.Commands.Requests;
using CQRS_BLL.CQRS.Commands.Responses;
using CQRS_DAL.Repositories.Abstract;

namespace CQRS_BLL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        private readonly IProductCommandRepository _productRepository;

        public DeleteProductCommandHandler(IProductCommandRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public DeleteProductCommandResponse DeleteProduct(DeleteProductCommandRequest request)
        {
            var data = _productRepository.DeleteProduct(request.Id);
            if (data == null)
                return new DeleteProductCommandResponse();

            return new DeleteProductCommandResponse { IsSuccess = true };
        }
    }
}
