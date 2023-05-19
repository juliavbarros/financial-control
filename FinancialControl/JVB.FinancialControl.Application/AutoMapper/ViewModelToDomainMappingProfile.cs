using AutoMapper;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Domain.Commands.Currencies;
using JVB.FinancialControl.Domain.Commands.ExpenseCategories;
using JVB.FinancialControl.Domain.Commands.Expenses;
using JVB.FinancialControl.Domain.Commands.GoalCategories;
using JVB.FinancialControl.Domain.Commands.Goals;
using JVB.FinancialControl.Domain.Commands.Quotations;
using JVB.FinancialControl.Domain.Commands.Users;
using JVB.FinancialControl.Domain.Commands.UserTypes;

namespace JVB.FinancialControl.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GoalViewModel, RegisterNewGoalCommand>().ConstructUsing(c => new RegisterNewGoalCommand(c.Name, c.Description, c.TotalValue, c.EntryValue, c.QuantityInstallment, c.MonthlyInstallmentValue, c.BeginDate, c.EndDate, c.GoalCategoryId, c.UserId));

            CreateMap<GoalViewModel, UpdateGoalCommand>().ConstructUsing(c => new UpdateGoalCommand(c.Id, c.Name, c.Description, c.TotalValue, c.EntryValue, c.QuantityInstallment, c.MonthlyInstallmentValue, c.BeginDate, c.EndDate, c.GoalCategoryId, c.UserId));

            CreateMap<GoalCategoryViewModel, RegisterNewGoalCategoryCommand>().ConstructUsing(c => new RegisterNewGoalCategoryCommand(c.Name, c.Description));

            CreateMap<GoalCategoryViewModel, UpdateGoalCategoryCommand>().ConstructUsing(c => new UpdateGoalCategoryCommand(c.Id, c.Name, c.Description));

            CreateMap<UserViewModel, RegisterNewUserCommand>().ConstructUsing(c => new RegisterNewUserCommand(c.Username, c.Password, c.Email, c.FirstName, c.LastName, c.BirthDate, c.GrossSalary, c.NetSalary, c.UserTypeId));

            CreateMap<UserViewModel, UpdateUserCommand>().ConstructUsing(c => new UpdateUserCommand(c.Id, c.Username, c.Password, c.Email, c.FirstName, c.LastName, c.BirthDate, c.GrossSalary, c.NetSalary, c.UserTypeId));

            CreateMap<UserTypeViewModel, RegisterNewUserTypeCommand>().ConstructUsing(c => new RegisterNewUserTypeCommand(c.Name));

            CreateMap<UserTypeViewModel, UpdateUserTypeCommand>().ConstructUsing(c => new UpdateUserTypeCommand(c.Id, c.Name));

            CreateMap<CurrencyViewModel, RegisterNewCurrencyCommand>().ConstructUsing(c => new RegisterNewCurrencyCommand(c.Name, c.Code, c.Symbol));

            CreateMap<CurrencyViewModel, UpdateCurrencyCommand>().ConstructUsing(c => new UpdateCurrencyCommand(c.Id, c.Name, c.Code, c.Symbol));

            CreateMap<ExpenseCategoryViewModel, RegisterNewExpenseCategoryCommand>().ConstructUsing(c => new RegisterNewExpenseCategoryCommand(c.Name));

            CreateMap<ExpenseCategoryViewModel, UpdateExpenseCategoryCommand>().ConstructUsing(c => new UpdateExpenseCategoryCommand(c.Id, c.Name));

            CreateMap<QuotationViewModel, RegisterNewQuotationCommand>().ConstructUsing(c => new RegisterNewQuotationCommand(c.InitialValue, c.ConvertedValue, c.QuotationDate, c.Rate, c.FromCurrencyId, c.ToCurrencyId, c.UserId));

            CreateMap<ExpenseViewModel, RegisterNewExpenseCommand>().ConstructUsing(c => new RegisterNewExpenseCommand(c.Name, c.Description, c.Value, c.CurrentInstallment, c.Date, c.ExpenseCategoryId, c.UserId));

            CreateMap<ExpenseViewModel, UpdateExpenseCommand>().ConstructUsing(c => new UpdateExpenseCommand(c.Id, c.Name, c.Description, c.Value, c.CurrentInstallment, c.Date, c.ExpenseCategoryId, c.UserId));
        }
    }
}