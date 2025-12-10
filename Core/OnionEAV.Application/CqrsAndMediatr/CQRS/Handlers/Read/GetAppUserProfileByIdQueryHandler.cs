using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;
        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUserProfile", request.Id);
            return new GetAppUserProfileByIdQueryResult
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                AppUserId = value.AppUserId
            };
        }
    }
}