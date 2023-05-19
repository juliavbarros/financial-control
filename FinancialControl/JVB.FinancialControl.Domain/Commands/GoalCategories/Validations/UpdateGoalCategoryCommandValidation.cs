using JVB.FinancialControl.Domain.Commands.GoalCategories;

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