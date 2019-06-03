using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private static readonly ISet<T> _context = new HashSet<T>();

        public async Task<T> GetById(Guid entityId)
            => await Task.FromResult(_context
                .SingleOrDefault(x => x.Id == entityId));

        public async Task<IEnumerable<T>> GetAllAsync()
            => await Task.FromResult(_context.AsEnumerable());

        public async Task AddAsync(T entity)
        {
            _context.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }
    }
}