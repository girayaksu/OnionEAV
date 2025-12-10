using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeValueCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateProductAttributeValueCommandHandler : IRequestHandler<CreateProductAttributeValueCommand, int>
    {
        private readonly IProductAttributeValueRepository _repository;

        public CreateProductAttributeValueCommandHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var productAttributeValue = new ProductAttributeValue
            {
                ProductId = request.ProductId,
                ProductAttributeId = request.ProductAttributeId,
                Value = request.Value,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };

            await _repository.CreateAsync(productAttributeValue);
            return productAttributeValue.Id;
        }
    }
}
