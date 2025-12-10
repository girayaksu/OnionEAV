using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class CreateAppUserProfileCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanýcý ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Kullanýcý ID 1'den büyük olmalýdýr")]
        public int AppUserId { get; set; }
    }
}
