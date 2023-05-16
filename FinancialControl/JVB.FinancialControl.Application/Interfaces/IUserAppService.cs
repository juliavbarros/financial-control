using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<IEnumerable<UserViewModel>> GetAll();

        Task<UserViewModel> GetById(int id);

        Task<ValidationResult> Register(UserViewModel userViewModel);

        Task<ValidationResult> Update(UserViewModel userViewModel);

        Task<ValidationResult> Remove(int id);
    }
}