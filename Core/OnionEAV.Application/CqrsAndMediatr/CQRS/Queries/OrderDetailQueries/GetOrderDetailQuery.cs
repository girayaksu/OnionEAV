using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}