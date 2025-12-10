using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries
{
    public class GetProductAttributeValueQuery : IRequest<List<GetProductAttributeValueQueryResult>>
    {
    }
}
