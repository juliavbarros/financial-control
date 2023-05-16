using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface ITaxAppService : IDisposable
    {
        Task<IEnumerable<TaxViewModel>> GetAll();

        Task<TaxViewModel> GetById(int id);

        Task<ValidationResult> Register(TaxViewModel taxViewModel);

        Task<ValidationResult> Update(TaxViewModel taxViewModel);

        Task<ValidationResult> Remove(int id);
    }
}