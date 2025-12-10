using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IOrderRepository _repository;
        public GetOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderQueryResult
            {
                Id = x.Id,
                ShippingAddress = x.ShippingAddress,
                AppUserId = x.AppUserId
            }).ToList();
        }
    }
}