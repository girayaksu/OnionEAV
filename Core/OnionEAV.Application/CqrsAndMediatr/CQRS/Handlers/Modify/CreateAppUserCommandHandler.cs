using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, int>
    {
        private readonly IAppUserRepository _repository;
        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };
            await _repository.CreateAsync(appUser);
            return appUser.Id;
        }
    }
}