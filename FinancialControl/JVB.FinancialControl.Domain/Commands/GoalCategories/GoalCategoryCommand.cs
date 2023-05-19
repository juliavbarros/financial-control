using JVB.FinancialControl.Common.Bus;

namespace JVB.FinancialControl.Domain.Commands.GoalCategories
{
    public abstract class GoalCategoryCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}