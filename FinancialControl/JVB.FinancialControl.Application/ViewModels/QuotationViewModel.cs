using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class QuotationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The InitialValue is Required")]
        [DisplayName("Valor")]
        public decimal InitialValue { get; set; }

        [Required(ErrorMessage = "The ConvertedValue is Required")]
        [DisplayName("Valor Convertido")]
        public decimal ConvertedValue { get; set; }

        [Required(ErrorMessage = "The QuotationDate is Required")]
        [DisplayName("Data Conversao")]
        public DateTime QuotationDate { get; set; }

        [Required(ErrorMessage = "The Rate is Required")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "The FromCurrency is Required")]
        [DisplayName("Moeda Origem")]
        public int FromCurrencyId { get; set; }

        [Required(ErrorMessage = "The ToCurrency is Required")]
        [DisplayName("Moeda Destino")]
        public int ToCurrencyId { get; set; }

        [Required(ErrorMessage = "The UserId is Required")]
        [DisplayName("Usuario")]
        public int UserId { get; set; }

        [DisplayName("De")]
        public string FromCurrencyName { get; set; }

        [DisplayName("Para")]
        public string ToCurrencyName { get; set; }
    }
}