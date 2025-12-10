using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries
{
    public class GetProductAttributeValuesByProductIdQuery : IRequest<List<GetProductAttributeValueQueryResult>>
    {
        public int ProductId { get; set; }

        public GetProductAttributeValuesByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
