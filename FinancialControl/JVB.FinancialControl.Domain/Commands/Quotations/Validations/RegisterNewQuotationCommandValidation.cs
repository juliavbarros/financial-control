using JVB.FinancialControl.Domain.Commands.Quotations;

namespace JVB.FinancialControl.Domain.Commands.Quotations.Validations
{
    public class RegisterNewQuotationCommandValidation : QuotationValidation<RegisterNewQuotationCommand>
    {
        public RegisterNewQuotationCommandValidation()
        {
            ValidateRate();
            ValidateInitialValue();
            ValidateConvertedValue();
            ValidateQuotationDate();
            ValidateFromCurrencyId();
            ValidateToCurrencyId();
            ValidateUserId();

        }
    }
}