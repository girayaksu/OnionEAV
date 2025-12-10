using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppUsers()
        {
            List<GetAppUserQueryResult> values = await _mediator.Send(new GetAppUserQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById(int id)
        {
            GetAppUserByIdQueryResult value = await _mediator.Send(new GetAppUserByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserCommand command)
        {
            int appUserId = await _mediator.Send(command);
            return Ok(new { Message = "Kullanıcı başarıyla oluşturuldu", AppUserId = appUserId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Kullanıcı başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAppUser(int id)
        {
            await _mediator.Send(new RemoveAppUserCommand(id));
            return Ok(new { Message = "Kullanıcı başarıyla silindi" });
        }
    }
}
