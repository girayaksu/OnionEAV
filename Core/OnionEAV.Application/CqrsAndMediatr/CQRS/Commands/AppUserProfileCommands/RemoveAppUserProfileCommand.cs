using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand : IRequest
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalýdýr")]
        public int Id { get; set; }

        public RemoveAppUserProfileCommand(int id)
        {
            Id = id;
        }
    }
}
