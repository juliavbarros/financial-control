using JVB.FinancialControl.Domain.Commands.Currencies.Validations;

namespace JVB.FinancialControl.Domain.Commands.Currencies
{
    public class RegisterNewCurrencyCommand : CurrencyCommand
    {
        public RegisterNewCurrencyCommand(string name, string code, string symbol)
        {
            Name = name;
            Code = code;
            Symbol = symbol;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCurrencyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}