using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IQuotationAppService : IDisposable
    {
        Task<IEnumerable<QuotationViewModel>> GetAll();

        Task<QuotationViewModel> GetById(int id);

        Task<ValidationResult> Register(QuotationViewModel quotationViewModel);

    }
}