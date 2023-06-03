using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Currencies.Validations
{
    public abstract class CurrencyValidation<T> : AbstractValidator<T> where T : CurrencyCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o Nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateCode()
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Por favor insira o Codigo")
                .Length(2, 3).WithMessage("O Codigo deve ter entre 2 e 3 caracteres");
        }

        protected void ValidateSymbol()
        {
            RuleFor(c => c.Symbol)
                .NotEmpty().WithMessage("Please ensure you have entered the Symbol")
                .Length(1, 10).WithMessage("O Simbolo deve ter entre 1 e 10 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }
    }
}