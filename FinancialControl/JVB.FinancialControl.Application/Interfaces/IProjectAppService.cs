using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IProjectAppService : IDisposable
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();

        Task<ProjectViewModel> GetById(int id);

        Task<ValidationResult> Register(ProjectViewModel projectViewModel);

        Task<ValidationResult> Update(ProjectViewModel projectViewModel);

        Task<ValidationResult> Remove(int id);
    }
}