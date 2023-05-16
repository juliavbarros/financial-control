using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<Currency> GetById(int id);

        Task<IEnumerable<Currency>> GetAll();

        Task<Currency> GetByCode(string code);

        void Add(Currency currency);

        void Update(Currency currency);

        void Remove(Currency currency);
    }
}