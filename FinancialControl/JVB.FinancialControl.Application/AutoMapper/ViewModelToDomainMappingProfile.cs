using AutoMapper;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Domain.Commands.Currencies;
using JVB.FinancialControl.Domain.Commands.Customers;
using JVB.FinancialControl.Domain.Commands.ExpenseCategories;
using JVB.FinancialControl.Domain.Commands.Projects;
using JVB.FinancialControl.Domain.Commands.Taxes;
using JVB.FinancialControl.Domain.Commands.Users;
using JVB.FinancialControl.Domain.Commands.UserTypes;

namespace JVB.FinancialControl.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>().ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));

            CreateMap<CustomerViewModel, UpdateCustomerCommand>().ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<ProjectViewModel, RegisterNewProjectCommand>().ConstructUsing(c => new RegisterNewProjectCommand(c.Name, c.Description));

            CreateMap<ProjectViewModel, UpdateProjectCommand>().ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name, c.Description));

            CreateMap<UserViewModel, RegisterNewUserCommand>().ConstructUsing(c => new RegisterNewUserCommand(c.Username, c.Password, c.Email, c.FirstName, c.LastName, c.BirthDate, c.GrossSalary, c.NetSalary, c.UserTypeId));

            CreateMap<UserViewModel, UpdateUserCommand>().ConstructUsing(c => new UpdateUserCommand(c.Id, c.Username, c.Password, c.Email, c.FirstName, c.LastName, c.BirthDate, c.GrossSalary, c.NetSalary, c.UserTypeId));

            CreateMap<UserTypeViewModel, RegisterNewUserTypeCommand>().ConstructUsing(c => new RegisterNewUserTypeCommand(c.Name));

            CreateMap<UserTypeViewModel, UpdateUserTypeCommand>().ConstructUsing(c => new UpdateUserTypeCommand(c.Id, c.Name));

            CreateMap<CurrencyViewModel, RegisterNewCurrencyCommand>().ConstructUsing(c => new RegisterNewCurrencyCommand(c.Name,  c.Code, c.Symbol));

            CreateMap<CurrencyViewModel, UpdateCurrencyCommand>().ConstructUsing(c => new UpdateCurrencyCommand(c.Id, c.Name,  c.Code, c.Symbol));

            CreateMap<ExpenseCategoryViewModel, RegisterNewExpenseCategoryCommand>().ConstructUsing(c => new RegisterNewExpenseCategoryCommand(c.Name));

            CreateMap<ExpenseCategoryViewModel, UpdateExpenseCategoryCommand>().ConstructUsing(c => new UpdateExpenseCategoryCommand(c.Id, c.Name));

            CreateMap<TaxViewModel, RegisterNewTaxCommand>().ConstructUsing(c => new RegisterNewTaxCommand(c.Name, c.Description));

            CreateMap<TaxViewModel, UpdateTaxCommand>().ConstructUsing(c => new UpdateTaxCommand(c.Id, c.Name, c.Description));
        }
    }
}