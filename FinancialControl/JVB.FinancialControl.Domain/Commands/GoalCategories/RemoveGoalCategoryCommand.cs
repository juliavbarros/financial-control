using JVB.FinancialControl.Domain.Commands.GoalCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.GoalCategories
{
    public class RemoveGoalCategoryCommand : GoalCategoryCommand
    {
        public RemoveGoalCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveGoalCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}