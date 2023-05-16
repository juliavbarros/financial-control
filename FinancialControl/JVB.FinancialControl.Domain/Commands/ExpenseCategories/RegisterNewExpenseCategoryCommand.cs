using JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories
{
    public class RegisterNewExpenseCategoryCommand : ExpenseCategoryCommand
    {
        public RegisterNewExpenseCategoryCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewExpenseCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}