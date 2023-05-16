using JVB.FinancialControl.Domain.Commands.UserTypes.Validations;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public class RemoveUserTypeCommand : UserTypeCommand
    {
        public RemoveUserTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}