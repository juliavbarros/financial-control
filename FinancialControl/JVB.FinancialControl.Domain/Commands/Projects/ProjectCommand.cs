using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Projects
{
    public abstract class ProjectCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}