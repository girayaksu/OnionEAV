using MediatR;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands
{
    public class RemoveProductAttributeCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductAttributeCommand(int id)
        {
            Id = id;
        }
    }
}
