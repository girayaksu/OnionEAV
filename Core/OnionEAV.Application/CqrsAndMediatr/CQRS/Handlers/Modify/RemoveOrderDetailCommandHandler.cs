using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;
        public RemoveOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("OrderDetail", request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}