using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, int>
    {
        private readonly IOrderDetailRepository _repository;
        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };
            await _repository.CreateAsync(orderDetail);
            return orderDetail.Id;
        }
    }
}