using AlbaflexMvc.CrossCutting.Enum;
using AlbaflexMvc.Models;

namespace AlbaflexMvc.Data.Entities
{
    public class Product : BaseEntity
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public double Value { get; set; }
        public ProductType Type { get; set; }

        public Product(int code, string? description, double value, ProductType type)
        {
            Code = code;
            Description = description;
            Value = value;
            Type = type;
        }

        public void Update(ProductInputModel model)
        {
            Description = model.Description == Description ? Description : model.Description;
            Value = model.Value == Value ? Value: model.Value;
        }

        public ProductInputModel ToInputModel()
        {
            return new ProductInputModel()
            {
                Code = Code,
                Description = Description,
                Type = Type,
                Value = Value
            };
        }
    }
}
