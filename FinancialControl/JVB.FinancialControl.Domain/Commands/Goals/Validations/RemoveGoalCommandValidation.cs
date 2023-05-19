namespace JVB.FinancialControl.Domain.Commands.Goals.Validations
{
    public class RemoveGoalCommandValidation : GoalValidation<RemoveGoalCommand>
    {
        public RemoveGoalCommandValidation()
        {
            ValidateId();
        }
    }
}