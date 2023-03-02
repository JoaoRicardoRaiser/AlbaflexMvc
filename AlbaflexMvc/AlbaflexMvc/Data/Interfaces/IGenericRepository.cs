using AlbaflexMvc.Data.Entities;

namespace AlbaflexMvc.Data.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entities);
        void DeleteRange(IEnumerable<T> entities);
    }
}
