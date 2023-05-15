using AutoMapper;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Domain.Commands.Customers;
using JVB.FinancialControl.Domain.Commands.Projects;

namespace JVB.FinancialControl.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
             .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));

            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<ProjectViewModel, RegisterNewProjectCommand>()
           .ConstructUsing(c => new RegisterNewProjectCommand(c.Name, c.Description));

            CreateMap<ProjectViewModel, UpdateProjectCommand>()
                .ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name, c.Description));
        }
    }
}