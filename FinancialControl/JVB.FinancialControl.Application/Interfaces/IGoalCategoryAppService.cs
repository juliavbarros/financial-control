using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IGoalCategoryAppService : IDisposable
    {
        Task<IEnumerable<GoalCategoryViewModel>> GetAll();

        Task<GoalCategoryViewModel> GetById(int id);

        Task<ValidationResult> Register(GoalCategoryViewModel goalCategoryViewModel);

        Task<ValidationResult> Update(GoalCategoryViewModel goalCategoryViewModel);

        Task<ValidationResult> Remove(int id);
    }
}