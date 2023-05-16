using System.Runtime.Serialization;

namespace JVB.FinancialControl.Web.Models.Ecb.ViewModel
{
    public class EcbCurrencyViewModel
    {
        public string Name { get; set; }
        public List<CurrencyRateViewModel> Rates { get; set; }
    }

    public class CurrencyRateViewModel
    {
        public DateTime Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}
