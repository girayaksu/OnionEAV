using MediatR;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands
{
    public class RemoveProductAttributeValueCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductAttributeValueCommand(int id)
        {
            Id = id;
        }
    }
}
