using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Product", request.Id);
            return new GetProductByIdQueryResult
            {
                Id = value.Id,
                ProductName = value.ProductName,
                UnitPrice = value.UnitPrice,
                CategoryId = value.CategoryId
            };
        }
    }
}