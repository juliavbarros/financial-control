using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();

        Task<CustomerViewModel> GetById(int id);

        Task<ValidationResult> Register(CustomerViewModel customerViewModel);

        Task<ValidationResult> Update(CustomerViewModel customerViewModel);

        Task<ValidationResult> Remove(int id);
    }
}