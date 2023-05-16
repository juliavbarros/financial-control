using JVB.FinancialControl.Domain.Commands.Currencies;

namespace JVB.FinancialControl.Domain.Commands.Currencies.Validations
{
    public class RegisterNewCurrencyCommandValidation : CurrencyValidation<RegisterNewCurrencyCommand>
    {
        public RegisterNewCurrencyCommandValidation()
        {
            ValidateName();
            ValidateCode();
            ValidateSymbol();
        }
    }
}