using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _repository;
        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Product", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}