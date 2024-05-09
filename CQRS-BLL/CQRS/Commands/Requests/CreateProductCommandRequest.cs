﻿using CQRS_BLL.CQRS.Commands.Responses;
using MediatR;

namespace CQRS_BLL.CQRS.Commands.Requests
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
