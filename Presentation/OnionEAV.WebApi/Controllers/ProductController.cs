using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            List<GetProductQueryResult> values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            GetProductByIdQueryResult value = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            int productId = await _mediator.Send(command);
            return Ok(new { Message = "Ürün başarıyla oluşturuldu", ProductId = productId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Ürün başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return Ok(new { Message = "Ürün başarıyla silindi" });
        }
    }
}


