using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand>
    {
        private readonly IAppUserRepository _repository;
        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUser", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}