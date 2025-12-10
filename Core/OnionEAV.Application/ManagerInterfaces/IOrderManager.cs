using OnionEAV.Application.DTOClasses;
using OnionEAV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Application.ManagerInterfaces
{
    public interface IOrderManager : IManager<OrderDto, Order>
    {
    }
}
