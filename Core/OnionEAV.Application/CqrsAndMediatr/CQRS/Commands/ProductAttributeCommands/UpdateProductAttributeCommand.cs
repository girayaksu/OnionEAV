using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands
{
    public class UpdateProductAttributeCommand : IRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Özellik adı zorunludur")]
        [StringLength(100, ErrorMessage = "Özellik adı en fazla 100 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veri tipi zorunludur")]
        [StringLength(50, ErrorMessage = "Veri tipi en fazla 50 karakter olabilir")]
        public string DataType { get; set; }

        public bool IsRequired { get; set; }
        public int? CategoryId { get; set; }
        public int DisplayOrder { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; }
    }
}
