namespace JVB.FinancialControl.Data.Entities
{
    public class Quotation
    {
        public Quotation(int id, decimal initialValue, decimal convertedValue, DateTime quotationDate, decimal rate, int fromCurrencyId, int toCurrencyId, int userId)
        {
            Id = id;
            Rate = rate;
            InitialValue = initialValue;
            ConvertedValue = convertedValue;
            QuotationDate = quotationDate;
            FromCurrencyId = fromCurrencyId;
            ToCurrencyId = toCurrencyId;
            UserId = userId;
        }

        public Quotation()
        { }

        public int Id { get; set; }
        public decimal InitialValue { get; set; }
        public decimal ConvertedValue { get; set; }
        public DateTime QuotationDate { get; set; }
        public decimal Rate { get; set; }

        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public int UserId { get; set; }

        public virtual Currency FromCurrency { get; set; }
        public virtual Currency ToCurrency { get; set; }
        public virtual User User { get; set; }
    }
}