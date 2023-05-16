using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IUserTypeAppService : IDisposable
    {
        Task<IEnumerable<UserTypeViewModel>> GetAll();

        Task<UserTypeViewModel> GetById(int id);

        Task<ValidationResult> Register(UserTypeViewModel userTypeViewModel);

        Task<ValidationResult> Update(UserTypeViewModel userTypeViewModel);

        Task<ValidationResult> Remove(int id);
    }
}