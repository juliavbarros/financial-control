using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IExpenseCategoryAppService : IDisposable
    {
        Task<IEnumerable<ExpenseCategoryViewModel>> GetAll();

        Task<ExpenseCategoryViewModel> GetById(int id);

        Task<ValidationResult> Register(ExpenseCategoryViewModel expenseCategoryViewModel);

        Task<ValidationResult> Update(ExpenseCategoryViewModel expenseCategoryViewModel);

        Task<ValidationResult> Remove(int id);
    }
}