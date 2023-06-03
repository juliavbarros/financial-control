using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class QuotationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Valor inicial requerido")]
        [DisplayName("Valor")]
        public decimal InitialValue { get; set; }

        [Required(ErrorMessage = "Valor convertido requerido")]
        [DisplayName("Valor Convertido")]
        public decimal ConvertedValue { get; set; }

        [Required(ErrorMessage = "Data de conversao requerido")]
        [DisplayName("Data Conversao")]
        public DateTime QuotationDate { get; set; }

        [Required(ErrorMessage = "Taxa requerida")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Moeda de origem requerida")]
        [DisplayName("Moeda Origem")]
        public int FromCurrencyId { get; set; }

        [Required(ErrorMessage = "Moeda de destino requerida")]
        [DisplayName("Moeda Destino")]
        public int ToCurrencyId { get; set; }

        [Required(ErrorMessage = "Usuario requerido")]
        [DisplayName("Usuario")]
        public int UserId { get; set; }

        [DisplayName("De")]
        public string FromCurrencyName { get; set; }

        [DisplayName("Para")]
        public string ToCurrencyName { get; set; }
    }
}