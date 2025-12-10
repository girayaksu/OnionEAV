using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest
    {
        [Required(ErrorMessage = "ID zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "ID 1'den büyük olmalıdır")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(200, ErrorMessage = "Ürün adı en fazla 200 karakter olabilir")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Birim fiyat zorunludur")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Birim fiyat 0'dan büyük olmalıdır")]
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}