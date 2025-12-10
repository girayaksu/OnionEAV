using MediatR;
using OnionEAV.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionEAV.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;
        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                UserName = request.UserName,
                Password = request.Password
            });
        }
    }
}