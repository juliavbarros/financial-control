using JVB.FinancialControl.Domain.Commands.Goals.Validations;

namespace JVB.FinancialControl.Domain.Commands.Goals
{
    public class UpdateGoalCommand : GoalCommand
    {
        public UpdateGoalCommand(int id, string name, string description, decimal totalValue, decimal entryValue, int quantityInstallment, decimal monthlyInstallmentValue, DateTime? beginDate, DateTime? endDate, int goalCategortId, int userId)
        {
            Id = id;
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
            ValidationResult = new UpdateGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}