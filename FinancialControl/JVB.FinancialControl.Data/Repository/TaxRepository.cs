using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class TaxRepository : ITaxRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Tax> DbSet;

        public TaxRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Tax>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Tax> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Tax>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Tax> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(Tax tax)
        {
            DbSet.Add(tax);
        }

        public void Update(Tax tax)
        {
            DbSet.Update(tax);
        }

        public void Remove(Tax tax)
        {
            DbSet.Remove(tax);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}