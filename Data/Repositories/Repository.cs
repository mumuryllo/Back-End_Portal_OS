using Microsoft.EntityFrameworkCore;
using PortalOS.Data.Context;
using PortalOS.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PortalOS.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PortalOSDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(PortalOSDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void Delete(T entity)
            => _dbSet.Remove(entity);
    }
}
