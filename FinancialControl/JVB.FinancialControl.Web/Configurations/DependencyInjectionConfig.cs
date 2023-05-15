using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.Services;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Context;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Data.Repository;
using JVB.FinancialControl.Domain.Commands.Customers;
using JVB.FinancialControl.Domain.Commands.Projects;
using MediatR;

namespace JVB.FinancialControl.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Domain Bus(Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IProjectAppService, ProjectAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProjectCommand, ValidationResult>, ProjectCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}