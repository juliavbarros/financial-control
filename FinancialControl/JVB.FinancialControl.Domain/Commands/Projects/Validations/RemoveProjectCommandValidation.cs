namespace JVB.FinancialControl.Domain.Commands.Projects.Validations
{
    public class RemoveProjectCommandValidation : ProjectValidation<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidation()
        {
            ValidateId();
        }
    }
}