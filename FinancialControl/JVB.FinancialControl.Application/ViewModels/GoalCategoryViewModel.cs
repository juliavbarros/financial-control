using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class GoalCategoryViewModel
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
    }
}