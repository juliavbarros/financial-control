using JVB.FinancialControl.Domain.Commands.Projects.Validations;

namespace JVB.FinancialControl.Domain.Commands.Projects
{
    public class RegisterNewProjectCommand : ProjectCommand
    {
        public RegisterNewProjectCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}