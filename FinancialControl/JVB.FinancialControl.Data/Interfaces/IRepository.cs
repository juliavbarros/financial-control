namespace JVB.FinancialControl.Data.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}