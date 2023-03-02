using AlbaflexMvc.Models;

namespace AlbaflexMvc.Services.Interfaces
{
    public interface IProductService
    {
        Task<BudgetInformationModel> GetBudgetInformation();
        Task GenerateBudgetPdf();
        Task CreateAsync(ProductInputModel model);
        Task EditAsync(ProductInputModel model);
        Task DeleteAsync(int code);
    }
}
