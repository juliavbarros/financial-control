using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Goals.Validations
{
    public abstract class GoalValidation<T> : AbstractValidator<T> where T : GoalCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 300).WithMessage("The Name must have between 2 and 300 characters");
        }

        protected void ValidateTotalValue()
        {
            RuleFor(c => c.TotalValue)
                .NotEqual(0);
        }

        protected void ValidateEntryValue()
        {
            RuleFor(c => c.EntryValue)
                .NotEqual(0);
        }

        protected void ValidateQuantityInstallment()
        {
            RuleFor(c => c.QuantityInstallment)
                .NotEqual(0);
        }

        protected void ValidateMonthlyInstallmentValue()
        {
            RuleFor(c => c.MonthlyInstallmentValue)
                .NotEqual(0);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateUserId()
        {
            RuleFor(c => c.UserId)
                .NotEqual(0);
        }
    }
}