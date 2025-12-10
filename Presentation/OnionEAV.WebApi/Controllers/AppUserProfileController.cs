using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppUserProfiles()
        {
            List<GetAppUserProfileQueryResult> values = await _mediator.Send(new GetAppUserProfileQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfileById(int id)
        {
            GetAppUserProfileByIdQueryResult value = await _mediator.Send(new GetAppUserProfileByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileCommand command)
        {
            int appUserProfileId = await _mediator.Send(command);
            return Ok(new { Message = "Kullanıcı profili başarıyla oluşturuldu", AppUserProfileId = appUserProfileId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Kullanıcı profili başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAppUserProfile(int id)
        {
            await _mediator.Send(new RemoveAppUserProfileCommand(id));
            return Ok(new { Message = "Kullanıcı profili başarıyla silindi" });
        }
    }
}


