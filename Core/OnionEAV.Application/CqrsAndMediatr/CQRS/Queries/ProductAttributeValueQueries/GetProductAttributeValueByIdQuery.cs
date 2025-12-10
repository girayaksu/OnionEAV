using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries
{
    public class GetProductAttributeValueByIdQuery : IRequest<GetProductAttributeValueByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductAttributeValueByIdQuery(int id)
        {
            Id = id;
        }
    }
}
