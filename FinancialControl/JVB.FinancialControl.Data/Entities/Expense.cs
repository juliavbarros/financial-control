namespace JVB.FinancialControl.Data.Entities
{
    public class Expense
    {
        public Expense(int id, string name, string description, decimal value, int quantityInstallment, DateTime beginDate, DateTime endDate, int expenseCategoryId, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            QuantityInstallment = quantityInstallment;
            BeginDate = beginDate;
            EndDate = endDate;
            ExpenseCategoryId = expenseCategoryId;
            UserId = userId;
        }

        protected Expense()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int QuantityInstallment { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int UserId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual User User { get; set; }
    }
}