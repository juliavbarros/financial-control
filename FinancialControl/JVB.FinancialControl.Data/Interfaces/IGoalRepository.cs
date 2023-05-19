using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IGoalRepository : IRepository<Goal>
    {
        Task<Goal> GetById(int id);

        Task<IEnumerable<Goal>> GetAll();

        Task<Goal> GetByName(string name);

        void Add(Goal goal);

        void Update(Goal goal);

        void Remove(Goal goal);
    }
}