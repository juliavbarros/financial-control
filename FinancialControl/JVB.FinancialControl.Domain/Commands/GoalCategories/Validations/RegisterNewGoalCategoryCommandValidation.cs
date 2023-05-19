namespace JVB.FinancialControl.Domain.Commands.GoalCategories.Validations
{
    public class RegisterNewGoalCategoryCommandValidation : GoalCategoryValidation<RegisterNewGoalCategoryCommand>
    {
        public RegisterNewGoalCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}