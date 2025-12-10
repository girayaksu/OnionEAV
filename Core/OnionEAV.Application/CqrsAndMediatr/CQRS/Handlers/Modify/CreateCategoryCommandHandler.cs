using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                CategoryName = request.CategoryName,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                Description = request.Description
            };
            await _repository.CreateAsync(category);
            return category.Id;
        }
    }
}