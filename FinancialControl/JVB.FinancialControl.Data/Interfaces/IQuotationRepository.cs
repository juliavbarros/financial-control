using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IQuotationRepository : IRepository<Quotation>
    {
        Task<Quotation> GetById(int id);

        Task<IEnumerable<Quotation>> GetAll();

        void Add(Quotation quotation);

        void Update(Quotation quotation);

        void Remove(Quotation quotation);
    }
}