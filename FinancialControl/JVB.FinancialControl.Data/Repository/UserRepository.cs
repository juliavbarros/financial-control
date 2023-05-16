using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<User> DbSet;

        public UserRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<User>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<User> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await DbSet
                .Include(x => x.UserType)
                .ToListAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Username == userName);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(User user)
        {
            DbSet.Add(user);
        }

        public void Update(User user)
        {
            DbSet.Update(user);
        }

        public void Remove(User user)
        {
            DbSet.Remove(user);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}