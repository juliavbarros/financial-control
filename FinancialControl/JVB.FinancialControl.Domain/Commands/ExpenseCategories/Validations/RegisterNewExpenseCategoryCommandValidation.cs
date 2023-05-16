namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations
{
    public class RegisterNewExpenseCategoryCommandValidation : ExpenseCategoryValidation<RegisterNewExpenseCategoryCommand>
    {
        public RegisterNewExpenseCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}