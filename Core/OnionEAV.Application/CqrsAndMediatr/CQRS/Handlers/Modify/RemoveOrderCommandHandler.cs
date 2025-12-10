using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _repository;
        public RemoveOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Order", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}