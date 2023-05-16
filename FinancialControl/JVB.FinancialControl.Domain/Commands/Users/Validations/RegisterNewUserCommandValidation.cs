namespace JVB.FinancialControl.Domain.Commands.Users.Validations
{
    public class RegisterNewUserCommandValidation : UserValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidateFirstName();
            ValidateLastName();
            ValidateBirthDate();
            ValidateGrossSalary();
            ValidateNetSalary();
        }
    }
}