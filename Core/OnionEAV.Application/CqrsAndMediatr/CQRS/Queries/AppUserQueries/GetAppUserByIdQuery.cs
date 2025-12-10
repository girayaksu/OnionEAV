using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries
{
    public class GetAppUserByIdQuery : IRequest<GetAppUserByIdQueryResult>
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        public GetAppUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}