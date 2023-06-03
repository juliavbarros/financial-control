using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class CurrencyViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Codigo requerido")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(5, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Simbolo requerido")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Simbolo")]
        public string Symbol { get; set; }
    }
}