using JVB.FinancialControl.Domain.Commands.UserTypes.Validations;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public class RegisterNewUserTypeCommand : UserTypeCommand
    {
        public RegisterNewUserTypeCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}