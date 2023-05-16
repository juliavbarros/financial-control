using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVB.FinancialControl.Data.Repository
{
    public class UserTypeRepository : IUserTypeRepository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<UserType> DbSet;

        public UserTypeRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<UserType>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<UserType> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<UserType>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<UserType> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Add(UserType userType)
        {
            DbSet.Add(userType);
        }

        public void Update(UserType userType)
        {
            DbSet.Update(userType);
        }

        public void Remove(UserType userType)
        {
            DbSet.Remove(userType);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}