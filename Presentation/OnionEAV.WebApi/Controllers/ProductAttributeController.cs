using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAttributes()
        {
            List<GetProductAttributeQueryResult> values = await _mediator.Send(new GetProductAttributeQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAttributeById(int id)
        {
            GetProductAttributeByIdQueryResult value = await _mediator.Send(new GetProductAttributeByIdQuery(id));
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAttribute(CreateProductAttributeCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductAttributeById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAttribute(UpdateProductAttributeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttribute(int id)
        {
            await _mediator.Send(new RemoveProductAttributeCommand(id));
            return NoContent();
        }
    }
}
