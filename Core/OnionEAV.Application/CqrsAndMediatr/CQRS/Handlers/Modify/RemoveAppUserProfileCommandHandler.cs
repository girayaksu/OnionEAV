using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUserProfile", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}