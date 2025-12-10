using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            List<GetOrderQueryResult> values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            GetOrderByIdQueryResult value = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            int orderId = await _mediator.Send(command);
            return Ok(new { Message = "Sipariş başarıyla oluşturuldu", OrderId = orderId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Sipariş başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok(new { Message = "Sipariş başarıyla silindi" });
        }
    }
}


