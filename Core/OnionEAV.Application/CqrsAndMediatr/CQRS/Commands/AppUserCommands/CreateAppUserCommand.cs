using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class CreateAppUserCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre 6-100 karakter arasında olmalıdır")]
        public string Password { get; set; }
    }
}