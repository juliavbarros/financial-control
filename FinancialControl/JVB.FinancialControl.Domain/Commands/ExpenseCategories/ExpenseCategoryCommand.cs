using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories
{
    public abstract class ExpenseCategoryCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
    }
}