namespace JVB.FinancialControl.Domain.Commands.Projects.Validations
{
    public class RegisterNewProjectCommandValidation : ProjectValidation<RegisterNewProjectCommand>
    {
        public RegisterNewProjectCommandValidation()
        {
            ValidateName();
        }
    }
}