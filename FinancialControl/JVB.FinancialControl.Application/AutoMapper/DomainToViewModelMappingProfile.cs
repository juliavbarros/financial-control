using AutoMapper;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<User, UserViewModel>().ForMember(dest=> dest.UsertTypeName, opt => opt.MapFrom(src => src.UserType.Name));
            CreateMap<UserType, UserTypeViewModel>();
            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<ExpenseCategory, ExpenseCategoryViewModel>();
        }
    }
}