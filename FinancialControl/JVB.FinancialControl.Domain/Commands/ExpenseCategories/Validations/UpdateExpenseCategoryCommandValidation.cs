namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations
{
    public class UpdateExpenseCategoryCommandValidation : ExpenseCategoryValidation<UpdateExpenseCategoryCommand>
    {
        public UpdateExpenseCategoryCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}