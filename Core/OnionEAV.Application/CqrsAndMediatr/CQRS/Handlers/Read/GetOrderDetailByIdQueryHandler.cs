using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;
        public GetOrderDetailByIdQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("OrderDetail", request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = value.Id,
                OrderId = value.OrderId,
                ProductId = value.ProductId
            };
        }
    }
}