using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class RemoveAppUserCommand : IRequest
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        public RemoveAppUserCommand(int id)
        {
            Id = id;
        }
    }
}