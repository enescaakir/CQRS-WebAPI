using CQRS_BLL.CQRS.Commands.Requests;
using CQRS_BLL.CQRS.Handlers.CommandHandlers;
using CQRS_BLL.CQRS.Handlers.QueryHandlers;
using CQRS_BLL.CQRS.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        CreateProductCommandHandler _createProductCommandHandler;
        DeleteProductCommandHandler _deleteProductCommandHandler;
        GetProductsQueryHandler _getAllProductQueryHandler;
        GetProductByIdQueryHandler _getByIdProductQueryHandler;

        public ProductController(
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            GetProductsQueryHandler getAllProductQueryHandler,
            GetProductByIdQueryHandler getByIdProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _getByIdProductQueryHandler = getByIdProductQueryHandler;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] GetProductsQueryRequest request)
        {
            var result = _getAllProductQueryHandler.GetProducts(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProductById([FromQuery] GetProductByIdQueryRequest request)
        {
            var result = _getByIdProductQueryHandler.GetProductById(request);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductCommandRequest request)
        {
            var result = _createProductCommandHandler.CreateProduct(request);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] DeleteProductCommandRequest request)
        {
            var result = _deleteProductCommandHandler.DeleteProduct(request);
            return Ok(result);
        }
    }
}
