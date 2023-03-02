using AlbaflexMvc.CrossCutting.Enum;
using AlbaflexMvc.Data.Entities;

namespace AlbaflexMvc.Data.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<Product?> GetByCodeAsync(int code);
    }
}
