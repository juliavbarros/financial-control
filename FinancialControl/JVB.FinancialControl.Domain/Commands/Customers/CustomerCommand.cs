using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Customers
{
    public abstract class CustomerCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}