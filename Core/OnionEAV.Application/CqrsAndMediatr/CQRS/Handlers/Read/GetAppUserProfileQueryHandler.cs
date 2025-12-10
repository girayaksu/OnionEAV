using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetAppUserProfileQueryHandler : IRequestHandler<GetAppUserProfileQuery, List<GetAppUserProfileQueryResult>>
    {
        private readonly IAppUserProfileRepository _repository;
        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery request, CancellationToken cancellationToken)
        {
            List<AppUserProfile> values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppUserProfileQueryResult
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AppUserId = x.AppUserId
            }).ToList();
        }
    }
}