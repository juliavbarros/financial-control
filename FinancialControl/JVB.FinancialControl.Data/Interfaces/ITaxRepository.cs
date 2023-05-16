using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface ITaxRepository : IRepository<Project>
    {
        Task<Tax> GetById(int id);

        Task<IEnumerable<Tax>> GetAll();

        Task<Tax> GetByName(string name);

        void Add(Tax tax);

        void Update(Tax tax);

        void Remove(Tax tax);
    }
}