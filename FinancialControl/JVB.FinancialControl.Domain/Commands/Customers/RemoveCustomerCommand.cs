using JVB.FinancialControl.Domain.Commands.Customers.Validations;

namespace JVB.FinancialControl.Domain.Commands.Customers
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}