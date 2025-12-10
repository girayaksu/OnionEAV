using MediatR;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionEAV.Application.Exceptions;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Product", request.Id);
            value.ProductName = request.ProductName;
            value.UnitPrice = request.UnitPrice;
            value.CategoryId = request.CategoryId;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}