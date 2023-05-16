using JVB.FinancialControl.Domain.Commands.Currencies;
using JVB.FinancialControl.Domain.Commands.Currencies.Validations;

namespace JVB.FinancialControl.Domain.Commands.Projects.Validations
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