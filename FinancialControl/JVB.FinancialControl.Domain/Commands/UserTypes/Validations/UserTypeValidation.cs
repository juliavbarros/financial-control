using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.UserTypes.Validations
{
    public abstract class UserTypeValidation<T> : AbstractValidator<T> where T : UserTypeCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o nome")
                .Length(2, 150).WithMessage("O Nome deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }
    }
}