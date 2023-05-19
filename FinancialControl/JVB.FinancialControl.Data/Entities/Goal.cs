namespace JVB.FinancialControl.Data.Entities
{
    public class Goal
    {
        public Goal(int id, string name, string description, decimal totalValue, decimal entryValue, int quantityInstallment, decimal monthlyInstallmentValue, DateTime? beginDate, DateTime? endDate, int goalCategoryId, int userId)
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
            GoalCategoryId = goalCategoryId;
            UserId = userId;
        }

        protected Goal()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalValue { get; set; }
        public decimal EntryValue { get; set; }
        public int QuantityInstallment { get; set; }
        public decimal MonthlyInstallmentValue { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GoalCategoryId { get; set; }
        public int UserId { get; set; }
        public virtual GoalCategory GoalCategory { get; set; }
        public virtual User User { get; set; }
    }
}