using JVB.FinancialControl.Domain.Commands.Quotations.Validations;

namespace JVB.FinancialControl.Domain.Commands.Quotations
{
    public class RegisterNewQuotationCommand : QuotationCommand
    {
        public RegisterNewQuotationCommand(decimal initialValue, decimal convertedValue, DateTime quotationDate, decimal rate, int fromCurrencyId, int toCurrencyId, int userId)
        {
            Rate = rate;
            InitialValue = initialValue;
            ConvertedValue = convertedValue;
            QuotationDate = quotationDate;
            FromCurrencyId = fromCurrencyId;
            ToCurrencyId = toCurrencyId;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewQuotationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}