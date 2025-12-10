using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Sipariş ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Sipariş ID 1'den büyük olmalıdır")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Ürün ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Ürün ID 1'den büyük olmalıdır")]
        public int ProductId { get; set; }
    }
}