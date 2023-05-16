using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Taxes
{
    public abstract class TaxCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}