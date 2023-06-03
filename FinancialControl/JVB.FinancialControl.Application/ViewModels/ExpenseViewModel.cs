using JVB.FinancialControl.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class ExpenseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "E-mail requerido")]
        [MinLength(2)]
        [MaxLength(300)]
        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Valor requerido")]
        [DisplayName("Valor")]
        public decimal Value { get; set; }

        [DisplayName("Prestação Atual")]
        public int? CurrentInstallment { get; set; }

        [DisplayName("Data Início")]
        public DateTime Date { get; set; }

        [DisplayName("Categoria")]
        public int ExpenseCategoryId { get; set; }

        public string ExpenseCategoryName { get; set; }

        public int UserId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual User User { get; set; }
    }
}