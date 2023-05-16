using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(int id);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetByUserName(string userName);

        Task<User> GetByEmail(string email);

        void Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}