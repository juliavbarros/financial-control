using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> Login(string userName, string password);
    }
}