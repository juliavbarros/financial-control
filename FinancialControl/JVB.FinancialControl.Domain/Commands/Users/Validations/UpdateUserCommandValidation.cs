namespace JVB.FinancialControl.Domain.Commands.Users.Validations
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
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