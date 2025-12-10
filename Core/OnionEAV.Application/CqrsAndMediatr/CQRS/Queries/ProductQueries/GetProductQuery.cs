using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {
    }
}