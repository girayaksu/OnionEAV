using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Order", request.Id);
            value.ShippingAddress = request.ShippingAddress;
            value.AppUserId = request.AppUserId;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}