namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations
{
    public class RemoveExpenseCategoryCommandValidation : ExpenseCategoryValidation<RemoveExpenseCategoryCommand>
    {
        public RemoveExpenseCategoryCommandValidation()
        {
            ValidateId();
        }
    }
}