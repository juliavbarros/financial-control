using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Project> DbSet;

        public ProjectRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Project>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Project> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Project> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(Project project)
        {
            DbSet.Add(project);
        }

        public void Update(Project project)
        {
            DbSet.Update(project);
        }

        public void Remove(Project project)
        {
            DbSet.Remove(project);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}