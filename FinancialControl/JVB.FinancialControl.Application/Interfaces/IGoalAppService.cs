using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IGoalAppService : IDisposable
    {
        Task<IEnumerable<GoalViewModel>> GetAll();

        Task<GoalViewModel> GetById(int id);

        Task<ValidationResult> Register(GoalViewModel goalViewModel);

        Task<ValidationResult> Update(GoalViewModel goalViewModel);

        Task<ValidationResult> Remove(int id);
    }
}