using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Currencies
{
    public abstract class CurrencyCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public string Symbol { get; protected set; }
    }
}