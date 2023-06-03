using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories.Validations
{
    public abstract class ExpenseCategoryValidation<T> : AbstractValidator<T> where T : ExpenseCategoryCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o Nome")
                .Length(2, 150).WithMessage("O Nome deve ter entre 2 e 150 caracteres");
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