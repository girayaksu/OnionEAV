using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeQueries
{
    public class GetProductAttributeByIdQuery : IRequest<GetProductAttributeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductAttributeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
