using AlbaflexMvc.CrossCutting.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlbaflexMvc.Models
{
    public class ProductInputModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Código inválido")]
        [Required(ErrorMessage = "Código inválido")]
        public int Code { get; set; }

        [Required(ErrorMessage ="Descrição inválida")]
        public string? Description { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Valor inválido")]
        [Required(ErrorMessage = "Valor inválido")]
        public double Value { get; set; }

        public ProductType Type { get; set; }
    }
}
