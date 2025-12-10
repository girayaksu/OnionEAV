using OnionEAV.Domain.Entities;
using OnionEAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Contract.RepositoryInterfaces
{
    public interface IRepository<T> where T:class,IEntity
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> exp);

        Task CreateAsync(T entity);
        Task UpdateAsync(T oldEntity,T newEntity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
