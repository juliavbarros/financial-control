using JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories
{
    public class UpdateExpenseCategoryCommand : ExpenseCategoryCommand
    {
        public UpdateExpenseCategoryCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateExpenseCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}