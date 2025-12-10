using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateProductAttributeValueCommandHandler : IRequestHandler<UpdateProductAttributeValueCommand>
    {
        private readonly IProductAttributeValueRepository _repository;

        public UpdateProductAttributeValueCommandHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var productAttributeValue = await _repository.GetByIdAsync(request.Id);
            if (productAttributeValue == null)
                throw new NotFoundException("ProductAttributeValue", request.Id);

            productAttributeValue.ProductId = request.ProductId;
            productAttributeValue.ProductAttributeId = request.ProductAttributeId;
            productAttributeValue.Value = request.Value;
            productAttributeValue.UpdatedDate = DateTime.Now;
            productAttributeValue.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(productAttributeValue, productAttributeValue);
        }
    }
}
