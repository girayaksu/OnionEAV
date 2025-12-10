using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;
        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUserProfile", request.Id);
            value.FirstName = request.FirstName;
            value.LastName = request.LastName;
            value.AppUserId = request.AppUserId;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}