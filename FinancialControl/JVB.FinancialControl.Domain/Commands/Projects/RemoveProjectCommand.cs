using JVB.FinancialControl.Domain.Commands.Projects.Validations;

namespace JVB.FinancialControl.Domain.Commands.Projects
{
    public class RemoveProjectCommand : ProjectCommand
    {
        public RemoveProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}