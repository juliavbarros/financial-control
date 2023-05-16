namespace JVB.FinancialControl.Domain.Commands.Users.Validations
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }
}