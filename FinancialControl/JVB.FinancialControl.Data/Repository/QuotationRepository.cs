using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<Quotation> DbSet;

        public QuotationRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Quotation>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Quotation> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Quotation>> GetAll()
        {
            return await DbSet
                .Include(x=> x.FromCurrency)
                .Include(x=> x.ToCurrency)
                .ToListAsync();
        }

        public void Add(Quotation quotation)
        {
            DbSet.Add(quotation);
        }

        public void Update(Quotation quotation)
        {
            DbSet.Update(quotation);
        }

        public void Remove(Quotation quotation)
        {
            DbSet.Remove(quotation);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}