using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.UserTypes.Validations
{
    public abstract class UserTypeValidation<T> : AbstractValidator<T> where T : UserTypeCommand
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
    }
}