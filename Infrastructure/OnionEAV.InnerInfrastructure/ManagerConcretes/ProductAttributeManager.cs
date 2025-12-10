using AutoMapper;
using OnionEAV.Application.DTOClasses;
using OnionEAV.Application.ManagerInterfaces;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;

namespace OnionEAV.InnerInfrastructure.ManagerConcretes
{
    public class ProductAttributeManager(IProductAttributeRepository repository, IMapper mapper) : BaseManager<ProductAttributeDto, ProductAttribute>(repository, mapper), IProductAttributeManager
    {
        private readonly IProductAttributeRepository _repository = repository;
    }
}
