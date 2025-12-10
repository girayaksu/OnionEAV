using AutoMapper;
using OnionEAV.Application.DTOClasses;
using OnionEAV.Application.ManagerInterfaces;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.InnerInfrastructure.ManagerConcretes
{
    public class ProductManager(IProductRepository repository, IMapper mapper) : BaseManager<ProductDto, Product>(repository, mapper), IProductManager
    {
        private readonly IProductRepository _repository = repository;
    }
}
