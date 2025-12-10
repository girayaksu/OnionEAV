using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Category", request.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryName = value.CategoryName,
                Description = value.Description,
                Id = value.Id
            };
        }
    }
}