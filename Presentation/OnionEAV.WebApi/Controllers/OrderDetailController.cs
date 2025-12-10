using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            List<GetOrderDetailQueryResult> values = await _mediator.Send(new GetOrderDetailQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            GetOrderDetailByIdQueryResult value = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            int orderDetailId = await _mediator.Send(command);
            return Ok(new { Message = "Sipariş detayı başarıyla oluşturuldu", OrderDetailId = orderDetailId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Sipariş detayı başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok(new { Message = "Sipariş detayı başarıyla silindi" });
        }
    }
}


