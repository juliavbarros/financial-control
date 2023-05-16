using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Username is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MinLength(2)]
        [MaxLength(10)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Firstname is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Primeiro Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Último Nome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The GrossSalary is Required")]
        [DisplayName("Salário Bruto")]
        public int GrossSalary { get; set; }

        [Required(ErrorMessage = "The NetSalary is Required")]
        [DisplayName("Salário Liquido")]
        public int NetSalary { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The UserTypeId is Required")]
        [DisplayName("Tipo Usuário")]
        public int UserTypeId { get; set; }
        public string UsertTypeName { get; set; }
    }
}