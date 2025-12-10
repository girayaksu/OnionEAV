using MediatR;
using OnionEAV.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using OnionEAV.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionEAV.Application.CqrsAndMediatr.Mediator.Handlers.Read
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
                Password = x.Password,
                UserName = x.UserName
            }).ToList();
        }
    }
}