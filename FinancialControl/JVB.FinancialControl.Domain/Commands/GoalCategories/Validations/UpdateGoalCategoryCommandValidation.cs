namespace JVB.FinancialControl.Domain.Commands.GoalCategories.Validations
{
    public class UpdateGoalCategoryCommandValidation : GoalCategoryValidation<UpdateGoalCategoryCommand>
    {
        public UpdateGoalCategoryCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}