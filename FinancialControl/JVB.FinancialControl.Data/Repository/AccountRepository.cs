using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<User> DbSet;

        public AccountRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<User>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<User> Login(string userName, string password)
        {
            return await DbSet
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(c => c.Username == userName && c.Password  == password);
        }
    }
}