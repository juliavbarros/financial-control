using JVB.FinancialControl.Domain.Commands.Customers.Validations;

namespace JVB.FinancialControl.Domain.Commands.Customers
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}