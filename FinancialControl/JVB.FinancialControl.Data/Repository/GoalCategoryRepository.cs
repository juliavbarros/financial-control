using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class GoalCategoryRepository : IGoalCategoryRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<GoalCategory> DbSet;

        public GoalCategoryRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<GoalCategory>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<GoalCategory> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<GoalCategory>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<GoalCategory> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(GoalCategory goalCategory)
        {
            DbSet.Add(goalCategory);
        }

        public void Update(GoalCategory goalCategory)
        {
            DbSet.Update(goalCategory);
        }

        public void Remove(GoalCategory goalCategory)
        {
            DbSet.Remove(goalCategory);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}