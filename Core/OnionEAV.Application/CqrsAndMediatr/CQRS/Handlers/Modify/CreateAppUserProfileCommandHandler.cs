using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, int>
    {
        private readonly IAppUserProfileRepository _repository;
        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = new AppUserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AppUserId = request.AppUserId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };
            await _repository.CreateAsync(appUserProfile);
            return appUserProfile.Id;
        }
    }
}