using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class GoalViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [MinLength(2)]
        [MaxLength(300)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The TotalValue is Required")]
        [DisplayName("Valor Final")]
        public decimal TotalValue { get; set; }

        [Required(ErrorMessage = "The EntryValue is Required")]
        [DisplayName("Valor de Entrada")]
        public decimal EntryValue { get; set; }

        [Required(ErrorMessage = "The QuantityInstallment is Required")]
        [DisplayName("Parcelas")]
        public int QuantityInstallment { get; set; }

        [Required(ErrorMessage = "The MonthlyInstallmentValue is Required")]
        [DisplayName("Parcela Mensal")]
        public decimal MonthlyInstallmentValue { get; set; }

        [Required(ErrorMessage = "The BeginDate is Required")]
        [DisplayName("Inicio")]
        public DateTime? BeginDate { get; set; }

        [Required(ErrorMessage = "The Fim is Required")]
        [DisplayName("Fim")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "The GoalCategoryId is Required")]
        [DisplayName("Categoria")]
        public int GoalCategoryId { get; set; }

        [Required(ErrorMessage = "The Value is Required")]
        [DisplayName("Usuario")]
        public int UserId { get; set; }
    }
}