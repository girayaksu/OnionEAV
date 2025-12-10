using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveProductAttributeValueCommandHandler : IRequestHandler<RemoveProductAttributeValueCommand>
    {
        private readonly IProductAttributeValueRepository _repository;

        public RemoveProductAttributeValueCommandHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var productAttributeValue = await _repository.GetByIdAsync(request.Id);
            if (productAttributeValue == null)
                throw new NotFoundException("ProductAttributeValue", request.Id);

            productAttributeValue.DeletedDate = DateTime.Now;
            productAttributeValue.Status = Domain.Enums.DataStatus.Deleted;
            await _repository.UpdateAsync(productAttributeValue, productAttributeValue);
        }
    }
}
