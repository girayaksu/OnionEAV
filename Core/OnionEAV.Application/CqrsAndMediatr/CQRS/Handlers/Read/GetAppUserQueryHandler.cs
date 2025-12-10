using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        private readonly IAppUserRepository _repository;
        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppUserQueryResult
            {
                Id = x.Id,
                UserName = x.UserName
            }).ToList();
        }
    }
}