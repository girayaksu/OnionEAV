using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        private readonly IAppUserRepository _repository;
        public GetAppUserByIdQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("AppUser", request.Id);
            return new GetAppUserByIdQueryResult
            {
                Id = value.Id,
                UserName = value.UserName
            };
        }
    }
}