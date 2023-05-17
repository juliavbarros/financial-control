using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class QuotationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(300)]
        [DisplayName("Descricao")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The InitialValue is Required")]
        [DisplayName("Valor")]
        public decimal InitialValue { get; set; }

        [Required(ErrorMessage = "The ConvertedValue is Required")]
        [DisplayName("Valor Convertido")]
        public decimal ConvertedValue { get; set; }

        [Required(ErrorMessage = "The QuotationDate is Required")]
        [DisplayName("Data Conversao")]
        public DateTime QuotationDate { get; set; }

        [Required(ErrorMessage = "The FromCurrency is Required")]
        [DisplayName("Moeda Origem")]
        public int FromCurrencyId { get; set; }

        [Required(ErrorMessage = "The ToCurrency is Required")]
        [DisplayName("Moeda Destino")]
        public int ToCurrencyId { get; set; }

        [Required(ErrorMessage = "The UserId is Required")]
        [DisplayName("Usuario")]
        public int UserId { get; set; }

        public string FromCurrencyName { get; set; }

        public string ToCurrencyName { get; set; }
    }
}