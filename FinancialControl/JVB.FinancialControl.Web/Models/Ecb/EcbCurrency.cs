namespace JVB.FinancialControl.Web.Models.Ecb
{
    public class EcbCurrency
    {
        public string Name { get; set; }
        public List<CurrencyRate> Rates { get; set; }
    }

    public class CurrencyRate
    {
        public DateTime Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}