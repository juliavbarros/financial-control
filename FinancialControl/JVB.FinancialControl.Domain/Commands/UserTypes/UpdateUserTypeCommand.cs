using JVB.FinancialControl.Domain.Commands.UserTypes.Validations;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public class UpdateUserTypeCommand : UserTypeCommand
    {
        public UpdateUserTypeCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}