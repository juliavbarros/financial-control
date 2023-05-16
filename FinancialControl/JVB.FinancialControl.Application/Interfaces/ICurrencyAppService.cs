using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface ICurrencyAppService : IDisposable
    {
        Task<IEnumerable<CurrencyViewModel>> GetAll();

        Task<CurrencyViewModel> GetById(int id);

        Task<ValidationResult> Register(CurrencyViewModel currencyViewModel);

        Task<ValidationResult> Update(CurrencyViewModel currencyViewModel);

        Task<ValidationResult> Remove(int id);
    }
}