namespace JVB.FinancialControl.Domain.Commands.Expenses.Validations
{
    public class RemoveExpenseCommandValidation : ExpenseValidation<RemoveExpenseCommand>
    {
        public RemoveExpenseCommandValidation()
        {
            ValidateId();
        }
    }
}