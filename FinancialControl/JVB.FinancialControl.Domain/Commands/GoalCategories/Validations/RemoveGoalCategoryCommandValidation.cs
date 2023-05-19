namespace JVB.FinancialControl.Domain.Commands.GoalCategories.Validations
{
    public class RemoveGoalCategoryCommandValidation : GoalCategoryValidation<RemoveGoalCategoryCommand>
    {
        public RemoveGoalCategoryCommandValidation()
        {
            ValidateId();
        }
    }
}