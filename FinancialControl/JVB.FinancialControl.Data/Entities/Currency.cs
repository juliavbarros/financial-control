namespace JVB.FinancialControl.Data.Entities
{
    public class Currency
    {
        public Currency(int id, string name, string code, string symbol)
        {
            Id = id;
            Name = name;
            Code = code;
            Symbol = symbol;
        }

        protected Currency()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<Quotation> FromQuotations { get; set; }
        public virtual ICollection<Quotation> ToQuotations { get; set; }
    }
}