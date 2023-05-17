using FluentValidation;
using JVB.FinancialControl.Domain.Commands.Quotations;

namespace JVB.FinancialControl.Domain.Commands.Quotations.Validations
{
    public abstract class QuotationValidation<T> : AbstractValidator<T> where T : QuotationCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 300).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateInitialValue()
        {
            RuleFor(c => c.InitialValue)
                .NotEqual(0);
        }
        protected void ValidateConvertedValue()
        {
            RuleFor(c => c.ConvertedValue)
                .NotEqual(0);
        }

        protected void ValidateQuotationDate()
        {
            RuleFor(c => c.QuotationDate).NotEmpty();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateFromCurrencyId()
        {
            RuleFor(c => c.FromCurrencyId)
                .NotEqual(0);
        }

        protected void ValidateToCurrencyId()
        {
            RuleFor(c => c.ToCurrencyId)
                .NotEqual(0);
        }

        protected void ValidateUserId()
        {
            RuleFor(c => c.UserId)
                .NotEqual(0);
        }
    }
}