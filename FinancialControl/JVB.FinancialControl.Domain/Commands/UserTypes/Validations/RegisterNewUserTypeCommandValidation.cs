namespace JVB.FinancialControl.Domain.Commands.UserTypes.Validations
{
    public class RegisterNewUserTypeCommandValidation : UserTypeValidation<RegisterNewUserTypeCommand>
    {
        public RegisterNewUserTypeCommandValidation()
        {
            ValidateName();
        }
    }
}