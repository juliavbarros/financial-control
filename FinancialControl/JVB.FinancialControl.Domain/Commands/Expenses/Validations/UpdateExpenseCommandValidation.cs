using JVB.FinancialControl.Domain.Commands.Expenses;

namespace JVB.FinancialControl.Domain.Commands.Expenses.Validations
{
    public class UpdateExpenseCommandValidation : ExpenseValidation<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidation()
        {
            ValidateId();
            ValidateValue();
            ValidateExpenseCategoryId();
            ValidateUserId();
        }
    }
}