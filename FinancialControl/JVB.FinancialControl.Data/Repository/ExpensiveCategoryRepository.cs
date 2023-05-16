using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<ExpenseCategory> DbSet;

        public ExpenseCategoryRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<ExpenseCategory>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<ExpenseCategory> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ExpenseCategory> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(ExpenseCategory expenseCategory)
        {
            DbSet.Add(expenseCategory);
        }

        public void Update(ExpenseCategory expenseCategory)
        {
            DbSet.Update(expenseCategory);
        }

        public void Remove(ExpenseCategory expenseCategory)
        {
            DbSet.Remove(expenseCategory);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}