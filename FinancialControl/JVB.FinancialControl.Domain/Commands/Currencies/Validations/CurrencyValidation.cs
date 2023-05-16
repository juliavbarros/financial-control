using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Currencies.Validations
{
    public abstract class CurrencyValidation<T> : AbstractValidator<T> where T : CurrencyCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateCode()
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Please ensure you have entered the Code")
                .Length(2, 3).WithMessage("The Code must have between 2 and 3 characters");
        }

        protected void ValidateSymbol()
        {
            RuleFor(c => c.Symbol)
                .NotEmpty().WithMessage("Please ensure you have entered the Symbol")
                .Length(1, 10).WithMessage("The Symbol must have between 1 and 10 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }
    }
}