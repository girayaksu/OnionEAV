using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeValueQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductAttributeValueByIdQueryHandler : IRequestHandler<GetProductAttributeValueByIdQuery, GetProductAttributeValueByIdQueryResult>
    {
        private readonly IProductAttributeValueRepository _repository;

        public GetProductAttributeValueByIdQueryHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductAttributeValueByIdQueryResult> Handle(GetProductAttributeValueByIdQuery request, CancellationToken cancellationToken)
        {
            var productAttributeValue = await _repository.GetByIdAsync(request.Id);
            if (productAttributeValue == null || productAttributeValue.Status == Domain.Enums.DataStatus.Deleted)
                return null;

            return new GetProductAttributeValueByIdQueryResult
            {
                Id = productAttributeValue.Id,
                ProductId = productAttributeValue.ProductId,
                ProductAttributeId = productAttributeValue.ProductAttributeId,
                Value = productAttributeValue.Value,
                ProductName = productAttributeValue.Product?.ProductName,
                AttributeName = productAttributeValue.ProductAttribute?.Name
            };
        }
    }
}
