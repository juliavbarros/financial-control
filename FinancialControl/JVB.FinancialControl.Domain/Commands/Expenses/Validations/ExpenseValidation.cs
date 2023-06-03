using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Expenses.Validations
{
    public abstract class ExpenseValidation<T> : AbstractValidator<T> where T : ExpenseCommand
    {
        protected void ValidateValue()
        {
            RuleFor(c => c.Value)
                .NotEqual(0).WithMessage("O valor não pode ser igual a 0");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateExpenseCategoryId()
        {
            RuleFor(c => c.ExpenseCategoryId)
                .NotEqual(0);
        }

        protected void ValidateUserId()
        {
            RuleFor(c => c.UserId)
                .NotEqual(0);
        }
    }
}