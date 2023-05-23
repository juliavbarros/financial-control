using JVB.FinancialControl.Domain.Commands.Users.Validations;

namespace JVB.FinancialControl.Domain.Commands.Users
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}