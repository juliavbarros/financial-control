using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Quotations
{
    public abstract class QuotationCommand : Command
    {
        public int Id { get; protected set; }

        public string Description { get; protected set; }
        public decimal InitialValue { get; protected set; }
        public decimal ConvertedValue { get; protected set; }
        public int FromCurrencyId { get; protected set; }
        public int ToCurrencyId { get; protected set; }
        public int UserId { get; protected set; }
        public DateTime QuotationDate { get; protected set; }
    }
}