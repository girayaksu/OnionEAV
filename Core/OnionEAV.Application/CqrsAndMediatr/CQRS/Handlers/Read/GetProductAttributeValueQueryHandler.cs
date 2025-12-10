using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductAttributeValueQueryHandler : IRequestHandler<GetProductAttributeValueQuery, List<GetProductAttributeValueQueryResult>>
    {
        private readonly IProductAttributeValueRepository _repository;

        public GetProductAttributeValueQueryHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductAttributeValueQueryResult>> Handle(GetProductAttributeValueQuery request, CancellationToken cancellationToken)
        {
            var productAttributeValues = await _repository.GetAllAsync();
            return productAttributeValues.Where(x => x.Status != Domain.Enums.DataStatus.Deleted)
                .Select(x => new GetProductAttributeValueQueryResult
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductAttributeId = x.ProductAttributeId,
                    Value = x.Value,
                    ProductName = x.Product?.ProductName,
                    AttributeName = x.ProductAttribute?.Name
                }).ToList();
        }
    }
}
