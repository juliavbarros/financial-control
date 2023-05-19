using JVB.FinancialControl.Domain.Commands.Goals.Validations;

namespace JVB.FinancialControl.Domain.Commands.Goals
{
    public class RegisterNewGoalCommand : GoalCommand
    {
        public RegisterNewGoalCommand(string name, string description, decimal totalValue, decimal entryValue, int quantityInstallment, decimal monthlyInstallmentValue, DateTime? beginDate, DateTime? endDate, int goalCategortId, int userId)
        {
            Name = name;
            Description = description;
            TotalValue = totalValue;
            EntryValue = entryValue;
            QuantityInstallment = quantityInstallment;
            MonthlyInstallmentValue = monthlyInstallmentValue;
            BeginDate = beginDate;
            EndDate = endDate;
            GoalCategoryId = goalCategortId;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}