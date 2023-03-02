using AlbaflexMvc.Data.Entities;

namespace AlbaflexMvc.Models
{
    public class BudgetInformationModel
    {
        public List<Product> Tissues { get; set; } = new();
        public List<Product> Materials { get; set; } = new();
        public List<Product> CaixaBox { get; set; } = new();
    }
}
