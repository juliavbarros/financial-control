namespace JVB.FinancialControl.Web.Models.Ecb.ViewModel
{
    public class CurrencyConvertionViewModel
    {
        public decimal FromRate { get; set; }
        public decimal ToRate { get; set; }
        public decimal Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}