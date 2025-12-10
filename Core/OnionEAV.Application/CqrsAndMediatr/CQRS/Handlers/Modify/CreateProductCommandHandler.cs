using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };
            await _repository.CreateAsync(product);
            return product.Id;
        }
    }
}