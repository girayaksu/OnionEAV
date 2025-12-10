using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Category", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}