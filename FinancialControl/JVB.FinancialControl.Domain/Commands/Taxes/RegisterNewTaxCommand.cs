using JVB.FinancialControl.Domain.Commands.Taxes.Validations;

namespace JVB.FinancialControl.Domain.Commands.Taxes
{
    public class RegisterNewTaxCommand : TaxCommand
    {
        public RegisterNewTaxCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewTaxCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}