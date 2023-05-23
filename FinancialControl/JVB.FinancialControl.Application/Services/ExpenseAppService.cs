using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Common.Models;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Expenses;

namespace JVB.FinancialControl.Application.Services
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMediatorHandler _mediator;

        public ExpenseAppService(IMapper mapper,
                                  IExpenseRepository expenseRepository,
                                  IExpenseCategoryRepository expenseCategoryRepository,
                                  IUserRepository userRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
            _expenseCategoryRepository = expenseCategoryRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ExpenseViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ExpenseViewModel>>(await _expenseRepository.GetAll());
        }

        public async Task<IEnumerable<ExpenseMultiModel>> GetExpenseTable(int userId)
        {
            var expenses = await _expenseRepository.GetByUserId(userId);
            var categories = await _expenseCategoryRepository.GetAll();
            var returnModel = new List<ExpenseMultiModel>();

            foreach (var item in categories)
            {
                var newExpense = new ExpenseMultiModel();

                var expense = expenses.Where(x => x.ExpenseCategoryId == item.Id);

                newExpense.CategoryName = item.Name;
                newExpense.CategoryId = item.Id.ToString();
                newExpense.January = await GetValue(expense, 1);
                newExpense.JanuaryRowId = await GetRowId(expense, 1);
                newExpense.February =await GetValue(expense, 2);
                newExpense.FebruaryRowId =await GetRowId(expense, 2);
                newExpense.March = await GetValue(expense, 3);
                newExpense.MarchRowId = await GetRowId(expense, 3);
                newExpense.April = await GetValue(expense, 4);
                newExpense.AprilRowId = await GetRowId(expense, 4);
                newExpense.May = await GetValue(expense, 5);
                newExpense.MayRowId = await GetRowId(expense, 5);
                newExpense.June = await GetValue(expense, 6);
                newExpense.JuneRowId = await GetRowId(expense, 6);
                newExpense.July = await GetValue(expense, 7);
                newExpense.JulyRowId = await GetRowId(expense, 7);
                newExpense.August = await GetValue(expense, 8);
                newExpense.AugustRowId = await GetRowId(expense, 8);
                newExpense.September = await GetValue(expense, 9);
                newExpense.SeptemberRowId = await GetRowId(expense, 9);
                newExpense.October = await GetValue(expense, 10);
                newExpense.OctoberRowId = await GetRowId(expense, 10);
                newExpense.November = await GetValue(expense, 11);
                newExpense.NovemberRowId = await GetRowId(expense, 11);
                newExpense.December = await GetValue(expense, 12);
                newExpense.DecemberRowId = await GetRowId(expense, 12);
                returnModel.Add(newExpense);
            }
            return returnModel;
        }

        private async Task<decimal?> GetValue(IEnumerable<Expense> expense, int month)
        {
            return expense
                .FirstOrDefault(x => x.Date.Month == month) != null
                ? expense.FirstOrDefault(x => x.Date.Month == month)?.Value
                : 0;
        }

        private async Task<string?> GetRowId(IEnumerable<Expense> expense, int month)
        {
            return expense
                .FirstOrDefault(x => x.Date.Month == month) != null
                ? expense.FirstOrDefault(x => x.Date.Month == month)?.Id.ToString()
                : string.Empty;
        }

        public async Task<ExpenseViewModel> GetById(int id)
        {
            return _mapper.Map<ExpenseViewModel>(await _expenseRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ExpenseViewModel expenseViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewExpenseCommand>(expenseViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ExpenseViewModel expenseViewModel)
        {
            var updateCommand = _mapper.Map<UpdateExpenseCommand>(expenseViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveExpenseCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<BarChartModel> GetRevenueExpensesData()
        {
            await GetExpensesByCategoryData();
            var user = await _userRepository.GetById(2);
            int currentMonth = DateTime.Now.Month;

            var expensesByUser = (await _expenseRepository.GetByUserId(2)).Where(x => x.Date.Month >= 1 && x.Date.Month <= currentMonth);

            decimal[] revenues = Enumerable.Repeat(user.NetSalary, currentMonth).ToArray();
            decimal[] expenses = Enumerable.Range(1, currentMonth)
                .Select(i => expensesByUser.Where(x => x.Date.Month == i).Sum(y => y.Value))
                .ToArray();

            return new BarChartModel
            {
                Expenses = expenses,
                Revenues = revenues
            };
        }

        public async Task<DonutChartModel> GetExpensesByCategoryData()
        {
            var user = await _userRepository.GetById(2);

            var expensesByUser = (await _expenseRepository.GetByUserId(2)).GroupBy(x => x.ExpenseCategory.Name);
            int quantity = expensesByUser.Count();
            string[] categories = new string[quantity];
            decimal[] expenses = new decimal[quantity];

            int counter = 0;
            foreach (var item in expensesByUser)
            {
                categories[counter] = item.Key;
                expenses[counter] = item.Sum(y => y.Value);
                counter++;
            }

            return new DonutChartModel
            {
                Category = categories,
                Expenses = expenses
            };
        }
    }
}