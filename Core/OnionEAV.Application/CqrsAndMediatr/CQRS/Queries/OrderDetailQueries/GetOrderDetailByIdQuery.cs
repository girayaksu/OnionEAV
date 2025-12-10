using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}