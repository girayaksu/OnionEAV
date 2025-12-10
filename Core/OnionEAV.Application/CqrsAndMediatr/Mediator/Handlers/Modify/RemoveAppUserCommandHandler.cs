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
            await _repository.DeleteAsync(value);
        }
    }
}