using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Login;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        Task<UserViewModel> Login(LoginViewModel loginViewModel);
    }
}