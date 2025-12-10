using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand>
    {
        private readonly IProductAttributeRepository _repository;

        public UpdateProductAttributeCommandHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var productAttribute = await _repository.GetByIdAsync(request.Id);
            if (productAttribute == null)
                throw new NotFoundException("ProductAttribute", request.Id);

            productAttribute.Name = request.Name;
            productAttribute.DataType = request.DataType;
            productAttribute.IsRequired = request.IsRequired;
            productAttribute.CategoryId = request.CategoryId;
            productAttribute.DisplayOrder = request.DisplayOrder;
            productAttribute.Description = request.Description;
            productAttribute.UpdatedDate = DateTime.Now;
            productAttribute.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(productAttribute, productAttribute);
        }
    }
}
