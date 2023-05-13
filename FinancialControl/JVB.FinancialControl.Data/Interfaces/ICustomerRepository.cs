using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetById(int id);

        Task<Customer> GetByEmail(string email);

        Task<IEnumerable<Customer>> GetAll();

        void Add(Customer customer);

        void Update(Customer customer);

        void Remove(Customer customer);
    }
}