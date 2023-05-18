using JVB.FinancialControl.Domain.Commands.Expenses.Validations;

namespace JVB.FinancialControl.Domain.Commands.Expenses
{
    public class RegisterNewExpenseCommand : ExpenseCommand
    {
        public RegisterNewExpenseCommand(string? name, string? description, decimal value, int? currentInstallment, DateTime date,  int expenseCategoryId, int userId)
        {
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
            ValidationResult = new RegisterNewExpenseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}