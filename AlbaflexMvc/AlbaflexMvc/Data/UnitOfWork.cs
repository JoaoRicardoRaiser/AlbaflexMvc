using AlbaflexMvc.Data.Entities;
using AlbaflexMvc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbaflexMvc.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private static DbContext _dbContext;
        
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public async Task CommitAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Select(x => x.Entity).ToList();
            foreach (BaseEntity entity in entities.Cast<BaseEntity>())
            {
                entity.UpdateAudit();
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
