using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}