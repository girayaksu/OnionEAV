using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Teslimat adresi zorunludur")]
        [StringLength(500, ErrorMessage = "Teslimat adresi en fazla 500 karakter olabilir")]
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}