using JVB.FinancialControl.Domain.Commands.Expenses.Validations;

namespace JVB.FinancialControl.Domain.Commands.Expenses
{
    public class UpdateExpenseCommand : ExpenseCommand
    {
        public UpdateExpenseCommand(int id, string? name, string? description, decimal value, int? currentInstallment, DateTime date, int expenseCategoryId, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            CurrentInstallment = currentInstallment;
            Date = date;
            ExpenseCategoryId = expenseCategoryId;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateExpenseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}