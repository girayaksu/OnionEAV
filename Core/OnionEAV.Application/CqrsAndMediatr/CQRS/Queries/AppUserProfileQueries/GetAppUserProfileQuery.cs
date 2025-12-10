using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileQuery : IRequest<List<GetAppUserProfileQueryResult>>
    {
    }
}