using OnionEAV.Application.DTOClasses;
using OnionEAV.Application.DTOInterfaces;
using OnionEAV.Domain.Entities;
using OnionEAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Application.ManagerInterfaces
{
    public interface IManager<T, U> where T : class, IDto where U : class, IEntity
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetUpdateds();


        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> SoftDeleteAsync(int id);
        Task<string> HardDeleteAsync(int id);
    }
}
