using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;
        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUser", request.Id);
            value.UserName = request.UserName;
            value.Password = request.Password;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}