using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Teslimat adresi zorunludur")]
        [StringLength(500, ErrorMessage = "Teslimat adresi en fazla 500 karakter olabilir")]
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}