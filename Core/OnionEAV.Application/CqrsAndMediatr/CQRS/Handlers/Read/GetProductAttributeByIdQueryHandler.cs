using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductAttributeByIdQueryHandler : IRequestHandler<GetProductAttributeByIdQuery, GetProductAttributeByIdQueryResult>
    {
        private readonly IProductAttributeRepository _repository;

        public GetProductAttributeByIdQueryHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductAttributeByIdQueryResult> Handle(GetProductAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var productAttribute = await _repository.GetByIdAsync(request.Id);
            if (productAttribute == null || productAttribute.Status == Domain.Enums.DataStatus.Deleted)
                return null;

            return new GetProductAttributeByIdQueryResult
            {
                Id = productAttribute.Id,
                Name = productAttribute.Name,
                DataType = productAttribute.DataType,
                IsRequired = productAttribute.IsRequired,
                CategoryId = productAttribute.CategoryId,
                DisplayOrder = productAttribute.DisplayOrder,
                Description = productAttribute.Description
            };
        }
    }
}
