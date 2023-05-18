using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Expenses
{
    public abstract class ExpenseCommand : Command
    {
        public int Id { get; protected set; }
        public string? Name { get; protected set; }
        public string? Description { get; protected set; }
        public decimal Value { get; protected set; }
        public DateTime Date { get; protected set; }
        public int? CurrentInstallment { get; protected set; }
        public int ExpenseCategoryId { get; protected set; }
        public int UserId { get; protected set; }
    }
}