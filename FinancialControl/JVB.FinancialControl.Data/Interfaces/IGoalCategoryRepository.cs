using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IGoalCategoryRepository : IRepository<GoalCategory>
    {
        Task<GoalCategory> GetById(int id);

        Task<IEnumerable<GoalCategory>> GetAll();

        Task<GoalCategory> GetByName(string name);

        void Add(GoalCategory goalCategory);

        void Update(GoalCategory goalCategory);

        void Remove(GoalCategory goalCategory);
    }
}