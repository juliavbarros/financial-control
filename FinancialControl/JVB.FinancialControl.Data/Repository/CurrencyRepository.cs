using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Currency> DbSet;

        public CurrencyRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Currency>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Currency> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Currency> GetByCode(string code)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Code == code);
        }

        public void Add(Currency currency)
        {
            DbSet.Add(currency);
        }

        public void Update(Currency currency)
        {
            DbSet.Update(currency);
        }

        public void Remove(Currency currency)
        {
            DbSet.Remove(currency);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}