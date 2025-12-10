using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries
{
    public class GetAppUserQuery : IRequest<List<GetAppUserQueryResult>>
    {
    }
}