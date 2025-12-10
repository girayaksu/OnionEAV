using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IOrderDetailRepository _repository;
        public GetOrderDetailQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            List<OrderDetail> values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId
            }).ToList();
        }
    }
}