using JVB.FinancialControl.Domain.Commands.Projects.Validations;

namespace JVB.FinancialControl.Domain.Commands.Projects
{
    public class UpdateProjectCommand : ProjectCommand
    {
        public UpdateProjectCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}