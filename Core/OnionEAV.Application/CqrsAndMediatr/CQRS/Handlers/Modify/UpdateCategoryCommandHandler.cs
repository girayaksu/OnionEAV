using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Category", request.Id);
            value.CategoryName = request.CategoryName;
            value.Description = request.Description;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}