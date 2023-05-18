namespace JVB.FinancialControl.Domain.Commands.Expenses.Validations
{
    public class RegisterNewExpenseCommandValidation : ExpenseValidation<RegisterNewExpenseCommand>
    {
        public RegisterNewExpenseCommandValidation()
        {
            ValidateValue();
            ValidateExpenseCategoryId();
            ValidateUserId();
        }
    }
}