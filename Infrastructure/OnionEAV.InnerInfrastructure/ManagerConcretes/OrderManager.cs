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
    public class OrderManager(IOrderRepository repository,IMapper mapper) : BaseManager<OrderDto,Order>(repository,mapper),IOrderManager
    {
        private readonly IOrderRepository _repository = repository;
    }
}
