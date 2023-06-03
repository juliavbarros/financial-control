using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Users.Validations
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateUsername()
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Por favor insira o Nome")
                .Length(2, 150).WithMessage("O Username deve ter entre 2 e 150 caracteres");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor insira a Senha")
                .Length(2, 10).WithMessage("A senha deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the First Name")
                .Length(2, 50).WithMessage("O Primeiro Nome deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the Last Name")
                .Length(2, 50).WithMessage("O último Nome deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("A idade deve ser superior a 18 anos");
        }

        protected void ValidateGrossSalary()
        {
            RuleFor(c => c.GrossSalary)
                .NotEmpty();
        }

        protected void ValidateNetSalary()
        {
            RuleFor(c => c.NetSalary)
                .NotEmpty();
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateUserTypeId()
        {
            RuleFor(c => c.UserTypeId)
                .NotEqual(0);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}