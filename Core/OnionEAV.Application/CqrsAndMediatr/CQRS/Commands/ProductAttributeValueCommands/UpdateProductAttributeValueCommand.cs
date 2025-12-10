using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands
{
    public class UpdateProductAttributeValueCommand : IRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün ID zorunludur")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Özellik ID zorunludur")]
        public int ProductAttributeId { get; set; }

        [Required(ErrorMessage = "Değer zorunludur")]
        [StringLength(1000, ErrorMessage = "Değer en fazla 1000 karakter olabilir")]
        public string Value { get; set; }
    }
}
