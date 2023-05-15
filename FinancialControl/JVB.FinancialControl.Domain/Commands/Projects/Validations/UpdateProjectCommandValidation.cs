namespace JVB.FinancialControl.Domain.Commands.Projects.Validations
{
    public class UpdateProjectCommandValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}