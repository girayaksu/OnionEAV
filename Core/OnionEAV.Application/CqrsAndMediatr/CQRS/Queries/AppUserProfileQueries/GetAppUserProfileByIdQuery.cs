using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdQueryResult>
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        public GetAppUserProfileByIdQuery(int id)
        {
            Id = id;
        }
    }
}