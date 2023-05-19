namespace JVB.FinancialControl.Domain.Commands.Goals.Validations
{
    public class UpdateGoalCommandValidation : GoalValidation<UpdateGoalCommand>
    {
        public UpdateGoalCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateTotalValue();
            ValidateEntryValue();
            ValidateQuantityInstallment();
            ValidateMonthlyInstallmentValue();
            ValidateUserId();
        }
    }
}