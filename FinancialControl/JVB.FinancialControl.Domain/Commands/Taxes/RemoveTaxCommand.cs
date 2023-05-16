using JVB.FinancialControl.Domain.Commands.Taxes.Validations;

namespace JVB.FinancialControl.Domain.Commands.Taxes
{
    public class RemoveTaxCommand : TaxCommand
    {
        public RemoveTaxCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveTaxCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}