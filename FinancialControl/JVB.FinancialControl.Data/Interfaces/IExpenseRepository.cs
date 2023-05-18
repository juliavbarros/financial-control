using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense> GetById(int id);

        Task<IEnumerable<Expense>> GetAll();
        Task<IEnumerable<Expense>> GetByUserId(int userId);

        void Add(Expense expense);

        void Update(Expense expense);

        void Remove(Expense expense);
    }
}