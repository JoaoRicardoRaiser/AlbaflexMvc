using AlbaflexMvc.Data.Entities;
using AlbaflexMvc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbaflexMvc.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product?> GetByCodeAsync(int code)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Code == code);
        }
    }
}
