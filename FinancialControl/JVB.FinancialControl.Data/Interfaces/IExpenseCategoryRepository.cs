using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IExpenseCategoryRepository : IRepository<ExpenseCategory>
    {
        Task<ExpenseCategory> GetById(int id);

        Task<IEnumerable<ExpenseCategory>> GetAll();

        Task<ExpenseCategory> GetByName(string name);

        void Add(ExpenseCategory project);

        void Update(ExpenseCategory project);

        void Remove(ExpenseCategory project);
    }
}