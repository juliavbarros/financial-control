using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.Services;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Data.Repository;
using JVB.FinancialControl.Domain.Commands.Currencies;
using JVB.FinancialControl.Domain.Commands.Customers;
using JVB.FinancialControl.Domain.Commands.ExpenseCategories;
using JVB.FinancialControl.Domain.Commands.Projects;
using JVB.FinancialControl.Domain.Commands.Taxes;
using JVB.FinancialControl.Domain.Commands.Users;
using JVB.FinancialControl.Domain.Commands.UserTypes;
using JVB.FinancialControl.Web.Services;
using MediatR;

namespace JVB.FinancialControl.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //common

            services.AddHttpClient<IEcbService, EcbService>();

            //Domain Bus(Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IProjectAppService, ProjectAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserTypeAppService, UserTypeAppService>();
            services.AddScoped<ICurrencyAppService, CurrencyAppService>();
            services.AddScoped<IExpenseCategoryAppService, ExpenseCategoryAppService>();
            services.AddScoped<ITaxAppService, TaxAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, ValidationResult>, UserCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewUserTypeCommand, ValidationResult>, UserTypeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserTypeCommand, ValidationResult>, UserTypeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserTypeCommand, ValidationResult>, UserTypeCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProjectCommand, ValidationResult>, ProjectCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCurrencyCommand, ValidationResult>, CurrencyCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCurrencyCommand, ValidationResult>, CurrencyCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCurrencyCommand, ValidationResult>, CurrencyCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewExpenseCategoryCommand, ValidationResult>, ExpenseCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateExpenseCategoryCommand, ValidationResult>, ExpenseCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveExpenseCategoryCommand, ValidationResult>, ExpenseCategoryCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewTaxCommand, ValidationResult>, TaxCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTaxCommand, ValidationResult>, TaxCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTaxCommand, ValidationResult>, TaxCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}