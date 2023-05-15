namespace JVB.FinancialControl.Data.Entities
{
    public class Simulation
    {
        public Simulation(int id, string name, string description, decimal totalValue, decimal entryValue, int quantityInstallment, decimal monthlyInstallmentValue, DateTime beginDate, DateTime endDate, int projectId, int taxId, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            TotalValue = totalValue;
            EntryValue = entryValue;
            QuantityInstallment = quantityInstallment;
            MonthlyInstallmentValue = monthlyInstallmentValue;
            BeginDate = beginDate;
            EndDate = endDate;
            ProjectId = projectId;
            TaxId = taxId;
            UserId = userId;
        }

        protected Simulation()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalValue { get; set; }
        public decimal EntryValue { get; set; }
        public int QuantityInstallment { get; set; }
        public decimal MonthlyInstallmentValue { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public int TaxId { get; set; }
        public int UserId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual User User { get; set; }
    }
}