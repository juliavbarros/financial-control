namespace JVB.FinancialControl.Data.Entities
{
    public class Expense
    {
        public Expense(int id, string? name, string? description, decimal value, int? currentInstallment, DateTime date, int expenseCategoryId, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            CurrentInstallment = currentInstallment;
            Date = date;
            ExpenseCategoryId = expenseCategoryId;
            UserId = userId;
        }

        public Expense()
        { }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public int? CurrentInstallment { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int UserId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual User User { get; set; }
    }
}