using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Users
{
    public abstract class UserCommand : Command
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public int UserTypeId { get; set; }
    }
}