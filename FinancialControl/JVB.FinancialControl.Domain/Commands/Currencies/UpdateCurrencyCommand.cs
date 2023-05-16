using JVB.FinancialControl.Domain.Commands.Currencies.Validations;

namespace JVB.FinancialControl.Domain.Commands.Currencies
{
    public class UpdateCurrencyCommand : CurrencyCommand
    {
        public UpdateCurrencyCommand(int id, string name, string code, string symbol)
        {
            Id = id;
            Name = name;
            Code = code;
            Symbol = symbol;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCurrencyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}