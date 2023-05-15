namespace JVB.FinancialControl.Data.Entities
{
    public class Currency
    {
        public Currency(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        protected Currency()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Quotation> FromQuotations { get; set; }
        public virtual ICollection<Quotation> ToQuotations { get; set; }
    }
}