using JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories
{
    public class RemoveExpenseCategoryCommand : ExpenseCategoryCommand
    {
        public RemoveExpenseCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveExpenseCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}