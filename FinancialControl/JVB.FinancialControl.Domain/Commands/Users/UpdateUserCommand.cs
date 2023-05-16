using JVB.FinancialControl.Domain.Commands.Users.Validations;

namespace JVB.FinancialControl.Domain.Commands.Users
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(int id, string username, string password, string email, string firstName, string lastName, DateTime birthDate, decimal grossSalary, decimal netSalary, int userTypeId)
        {
            Id = id;
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
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}