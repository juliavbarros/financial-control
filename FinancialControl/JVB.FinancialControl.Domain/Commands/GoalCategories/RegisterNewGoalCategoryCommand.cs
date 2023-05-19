using JVB.FinancialControl.Domain.Commands.GoalCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.GoalCategories
{
    public class RegisterNewGoalCategoryCommand : GoalCategoryCommand
    {
        public RegisterNewGoalCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewGoalCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}