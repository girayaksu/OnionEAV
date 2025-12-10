using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}