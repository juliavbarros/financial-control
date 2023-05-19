using JVB.FinancialControl.Domain.Commands.Goals.Validations;

namespace JVB.FinancialControl.Domain.Commands.Goals
{
    public class RemoveGoalCommand : GoalCommand
    {
        public RemoveGoalCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}