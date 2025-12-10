using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeQueries
{
    public class GetProductAttributeQuery : IRequest<List<GetProductAttributeQueryResult>>
    {
    }
}
