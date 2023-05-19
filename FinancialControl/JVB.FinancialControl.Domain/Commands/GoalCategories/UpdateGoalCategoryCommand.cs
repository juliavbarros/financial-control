using JVB.FinancialControl.Domain.Commands.GoalCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.GoalCategories
{
    public class UpdateGoalCategoryCommand : GoalCategoryCommand
    {
        public UpdateGoalCategoryCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateGoalCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}