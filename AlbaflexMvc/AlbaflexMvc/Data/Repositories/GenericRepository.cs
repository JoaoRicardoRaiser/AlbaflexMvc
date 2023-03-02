using AlbaflexMvc.Data.Entities;
using AlbaflexMvc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbaflexMvc.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _dbSet { get; private set; }

        public GenericRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
