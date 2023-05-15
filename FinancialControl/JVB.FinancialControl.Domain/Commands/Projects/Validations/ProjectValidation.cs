using FluentValidation;

namespace JVB.FinancialControl.Domain.Commands.Projects.Validations
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectCommand
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