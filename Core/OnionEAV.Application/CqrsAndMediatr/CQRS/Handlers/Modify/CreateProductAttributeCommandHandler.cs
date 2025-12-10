using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductAttributeCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateProductAttributeCommandHandler : IRequestHandler<CreateProductAttributeCommand, int>
    {
        private readonly IProductAttributeRepository _repository;

        public CreateProductAttributeCommandHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var productAttribute = new ProductAttribute
            {
                Name = request.Name,
                DataType = request.DataType,
                IsRequired = request.IsRequired,
                CategoryId = request.CategoryId,
                DisplayOrder = request.DisplayOrder,
                Description = request.Description,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };

            await _repository.CreateAsync(productAttribute);
            return productAttribute.Id;
        }
    }
}
