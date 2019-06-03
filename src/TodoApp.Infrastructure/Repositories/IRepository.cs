using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid entityId);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}