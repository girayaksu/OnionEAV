using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {
    }
}