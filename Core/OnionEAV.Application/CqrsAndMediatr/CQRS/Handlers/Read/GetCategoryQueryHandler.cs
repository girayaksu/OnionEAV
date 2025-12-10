using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }
    }
}