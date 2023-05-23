using JVB.FinancialControl.Domain.Commands.UserTypes.Validations;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public class RemoveUserTypeCommand : UserTypeCommand
    {
        public RemoveUserTypeCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}