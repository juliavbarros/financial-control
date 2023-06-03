using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class CurrencyViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Codigo requerido")]
        [MinLength(2)]
        [MaxLength(5)]
        [DisplayName("Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Simbolo requerido")]
        [MinLength(1)]
        [MaxLength(10)]
        [DisplayName("Simbolo")]
        public string Symbol { get; set; }
    }
}