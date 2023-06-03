using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha requerida")]
        [MinLength(2)]
        [MaxLength(10)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Primeiro nome requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Primeiro Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ultimo nome requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Último Nome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail requerido")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salario bruto requerido")]
        [DisplayName("Salário Bruto")]
        public int GrossSalary { get; set; }

        [Required(ErrorMessage = "Salario liquido requerido")]
        [DisplayName("Salário Liquido")]
        public int NetSalary { get; set; }

        [Required(ErrorMessage = "Data de nascimento requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Tipo de usuario requerido")]
        [DisplayName("Tipo Usuário")]
        public int UserTypeId { get; set; }

        public string? UsertTypeName { get; set; }
    }
}