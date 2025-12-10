using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("OrderDetail", request.Id);
            value.OrderId = request.OrderId;
            value.ProductId = request.ProductId;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}