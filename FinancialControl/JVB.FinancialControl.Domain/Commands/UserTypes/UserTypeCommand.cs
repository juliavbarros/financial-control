using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public abstract class UserTypeCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
    }
}