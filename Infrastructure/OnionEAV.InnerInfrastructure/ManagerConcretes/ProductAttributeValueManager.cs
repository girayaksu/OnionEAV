using AutoMapper;
using OnionEAV.Application.DTOClasses;
using OnionEAV.Application.ManagerInterfaces;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;

namespace OnionEAV.InnerInfrastructure.ManagerConcretes
{
    public class ProductAttributeValueManager(IProductAttributeValueRepository repository, IMapper mapper) : BaseManager<ProductAttributeValueDto, ProductAttributeValue>(repository, mapper), IProductAttributeValueManager
    {
        private readonly IProductAttributeValueRepository _repository = repository;
    }
}
