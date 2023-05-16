using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations
{
    public abstract class ExpenseCategoryValidation<T> : AbstractValidator<T> where T : ExpenseCategoryCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}