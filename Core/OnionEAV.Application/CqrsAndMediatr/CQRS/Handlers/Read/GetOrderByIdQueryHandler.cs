using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;
        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Order", request.Id);
            return new GetOrderByIdQueryResult
            {
                Id = value.Id,
                ShippingAddress = value.ShippingAddress,
                AppUserId = value.AppUserId
            };
        }
    }
}