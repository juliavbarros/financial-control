﻿using FluentValidation.Results;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Models;

namespace JVB.FinancialControl.Application.Interfaces
{
    public interface IExpenseAppService : IDisposable
    {
        Task<IEnumerable<ExpenseViewModel>> GetAll();

        Task<IEnumerable<ExpenseViewModel>> GetByUserId(int userId);

        Task<IEnumerable<ExpenseMultiModel>> GetExpenseTable(int userId);

        Task<BarChartModel> GetRevenueExpensesData(int userId);

        Task<DonutChartModel> GetExpensesByCategoryData(int userId);

        Task<ExpenseViewModel> GetById(int id);

        Task<ValidationResult> Register(ExpenseViewModel expenseViewModel);

        Task<ValidationResult> Update(ExpenseViewModel expenseViewModel);

        Task<ValidationResult> Remove(int id);
    }
}