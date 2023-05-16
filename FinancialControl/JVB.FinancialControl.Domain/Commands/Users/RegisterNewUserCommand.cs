using JVB.FinancialControl.Domain.Commands.Users.Validations;

namespace JVB.FinancialControl.Domain.Commands.Users
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string username, string password, string email, string firstName, string lastName, DateTime birthDate, decimal grossSalary, decimal netSalary, int userTypeId)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            GrossSalary = grossSalary;
            NetSalary = netSalary;
            UserTypeId = userTypeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}