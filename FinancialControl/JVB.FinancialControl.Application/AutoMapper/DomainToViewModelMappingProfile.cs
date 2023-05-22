using AutoMapper;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Data.Entities;

namespace JVB.FinancialControl.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>().ForMember(dest => dest.UsertTypeName, opt => opt.MapFrom(src => src.UserType.Name));
            CreateMap<UserType, UserTypeViewModel>();
            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<ExpenseCategory, ExpenseCategoryViewModel>();
            CreateMap<Quotation, QuotationViewModel>()
                .ForMember(dest => dest.FromCurrencyName, opt => opt.MapFrom(src => src.FromCurrency.Name))
                .ForMember(dest => dest.ToCurrencyName, opt => opt.MapFrom(src => src.ToCurrency.Name));
            CreateMap<Expense, ExpenseViewModel>()
            .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name));
        }
    }
}