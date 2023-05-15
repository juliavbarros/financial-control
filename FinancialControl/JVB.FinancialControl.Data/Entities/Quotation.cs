namespace JVB.FinancialControl.Data.Entities
{
    public class Quotation
    {
        public Quotation(int id, string description, decimal initialValue, decimal convertedValue, DateTime quotationDate, int fromCurrencyId, int toCurrencyId, int userId)
        {
            Id = id;
            Description = description;
            InitialValue = initialValue;
            ConvertedValue = convertedValue;
            QuotationDate = quotationDate;
            FromCurrencyId = fromCurrencyId;
            ToCurrencyId = toCurrencyId;
            UserId = userId;
        }

        protected Quotation()
        { }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal InitialValue { get; set; }
        public decimal ConvertedValue { get; set; }
        public DateTime QuotationDate { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public int UserId { get; set; }
        public virtual Currency FromCurrency { get; set; }
        public virtual Currency ToCurrency { get; set; }
        public virtual User User { get; set; }
    }
}