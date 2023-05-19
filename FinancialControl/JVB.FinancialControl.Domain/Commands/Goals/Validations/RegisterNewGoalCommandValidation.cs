namespace JVB.FinancialControl.Domain.Commands.Goals.Validations
{
    public class RegisterNewGoalCommandValidation : GoalValidation<RegisterNewGoalCommand>
    {
        public RegisterNewGoalCommandValidation()
        {
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