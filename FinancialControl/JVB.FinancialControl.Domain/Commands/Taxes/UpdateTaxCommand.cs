using JVB.FinancialControl.Domain.Commands.Taxes.Validations;

namespace JVB.FinancialControl.Domain.Commands.Taxes
{
    public class UpdateTaxCommand : TaxCommand
    {
        public UpdateTaxCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateTaxCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}