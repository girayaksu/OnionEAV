using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductAttributeQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductAttributeQueryHandler : IRequestHandler<GetProductAttributeQuery, List<GetProductAttributeQueryResult>>
    {
        private readonly IProductAttributeRepository _repository;

        public GetProductAttributeQueryHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductAttributeQueryResult>> Handle(GetProductAttributeQuery request, CancellationToken cancellationToken)
        {
            var productAttributes = await _repository.GetAllAsync();
            return productAttributes.Where(x => x.Status != Domain.Enums.DataStatus.Deleted)
                .Select(x => new GetProductAttributeQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataType = x.DataType,
                    IsRequired = x.IsRequired,
                    CategoryId = x.CategoryId,
                    DisplayOrder = x.DisplayOrder,
                    Description = x.Description
                }).ToList();
        }
    }
}
