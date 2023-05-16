using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IUserTypeRepository : IRepository<UserType>
    {
        Task<UserType> GetById(int id);

        Task<IEnumerable<UserType>> GetAll();

        Task<UserType> GetByName(string userType);

        void Add(UserType userType);

        void Update(UserType userType);

        void Remove(UserType userType);
    }
}