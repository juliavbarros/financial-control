using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class UserTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}