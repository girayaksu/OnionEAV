using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IProductRepository _repository;
        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> values = await _repository.GetAllAsync();
            return values.Select(x => new GetProductQueryResult
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId
            }).ToList();
        }
    }
}