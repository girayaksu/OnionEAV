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
            return new GetAppUserByIdQueryResult
            {
                Id = value.Id,
                Password = value.Password,
                UserName = value.UserName
            };
        }
    }
}