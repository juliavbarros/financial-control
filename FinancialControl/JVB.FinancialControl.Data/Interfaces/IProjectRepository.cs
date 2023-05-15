using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetById(int id);

        Task<IEnumerable<Project>> GetAll();

        Task<Project> GetByName(string name);

        void Add(Project project);

        void Update(Project project);

        void Remove(Project project);
    }
}