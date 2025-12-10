using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeValueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAttributeValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAttributeValues()
        {
            List<GetProductAttributeValueQueryResult> values = await _mediator.Send(new GetProductAttributeValueQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAttributeValueById(int id)
        {
            GetProductAttributeValueByIdQueryResult value = await _mediator.Send(new GetProductAttributeValueByIdQuery(id));
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductAttributeValuesByProductId(int productId)
        {
            List<GetProductAttributeValueQueryResult> values = await _mediator.Send(new GetProductAttributeValuesByProductIdQuery(productId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAttributeValue(CreateProductAttributeValueCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductAttributeValueById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAttributeValue(UpdateProductAttributeValueCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttributeValue(int id)
        {
            await _mediator.Send(new RemoveProductAttributeValueCommand(id));
            return NoContent();
        }
    }
}
