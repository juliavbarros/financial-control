using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.Goals
{
    public abstract class GoalCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal TotalValue { get; set; }
        public decimal EntryValue { get; set; }
        public int QuantityInstallment { get; set; }
        public decimal MonthlyInstallmentValue { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GoalCategoryId { get; set; }
        public int UserId { get; set; }
    }
}