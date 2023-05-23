using JVB.FinancialControl.Domain.Commands.Currencies.Validations;

namespace JVB.FinancialControl.Domain.Commands.Currencies
{
    public class RemoveCurrencyCommand : CurrencyCommand
    {
        public RemoveCurrencyCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCurrencyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}