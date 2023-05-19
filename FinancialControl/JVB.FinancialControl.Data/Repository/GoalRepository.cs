using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class GoalRepository : IGoalRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Goal> DbSet;

        public GoalRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Goal>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Goal> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Goal>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Goal> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(Goal goal)
        {
            DbSet.Add(goal);
        }

        public void Update(Goal goal)
        {
            DbSet.Update(goal);
        }

        public void Remove(Goal goal)
        {
            DbSet.Remove(goal);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}