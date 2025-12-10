using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _repository;
        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ShippingAddress = request.ShippingAddress,
                AppUserId = request.AppUserId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };
            await _repository.CreateAsync(order);
            return order.Id;
        }
    }
}