using JVB.FinancialControl.Domain.Commands.Expenses.Validations;

namespace JVB.FinancialControl.Domain.Commands.Expenses
{
    public class RemoveExpenseCommand : ExpenseCommand
    {
        public RemoveExpenseCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveExpenseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}