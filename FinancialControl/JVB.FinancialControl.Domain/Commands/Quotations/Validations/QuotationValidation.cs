using FluentValidation;
using JVB.FinancialControl.Domain.Commands.Quotations;

namespace JVB.FinancialControl.Domain.Commands.Quotations.Validations
{
    public abstract class QuotationValidation<T> : AbstractValidator<T> where T : QuotationCommand
    {
        protected void ValidateRate()
        {
            RuleFor(c => c.Rate)
                .NotEqual(0);
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