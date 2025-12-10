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
            value.UserName = request.UserName;
            value.Password = request.Password;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
        }
    }
}