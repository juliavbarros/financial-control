namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}