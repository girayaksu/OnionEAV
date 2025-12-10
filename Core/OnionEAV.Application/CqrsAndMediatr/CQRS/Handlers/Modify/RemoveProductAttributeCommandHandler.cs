using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveProductAttributeCommandHandler : IRequestHandler<RemoveProductAttributeCommand>
    {
        private readonly IProductAttributeRepository _repository;

        public RemoveProductAttributeCommandHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var productAttribute = await _repository.GetByIdAsync(request.Id);
            if (productAttribute == null)
                throw new NotFoundException("ProductAttribute", request.Id);

            productAttribute.DeletedDate = DateTime.Now;
            productAttribute.Status = Domain.Enums.DataStatus.Deleted;
            await _repository.UpdateAsync(productAttribute, productAttribute);
        }
    }
}
