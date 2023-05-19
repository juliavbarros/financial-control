using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Expense> DbSet;

        public ExpenseRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Expense>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Expense> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetByUserId(int userId)
        {
            return await DbSet
                .Include(x => x.ExpenseCategory)
                .Where(x => x.UserId == userId).ToListAsync();
        }

        public void Add(Expense expense)
        {
            DbSet.Add(expense);
        }

        public void Update(Expense expense)
        {
            DbSet.Update(expense);
        }

        public void Remove(Expense expense)
        {
            DbSet.Remove(expense);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}