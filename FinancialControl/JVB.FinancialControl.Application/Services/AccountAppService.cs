using AutoMapper;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Common.Login;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Data.Repository;

namespace JVB.FinancialControl.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediatorHandler _mediator;

        public AccountAppService(IMapper mapper,
                                  IAccountRepository accountRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            return _mapper.Map<UserViewModel>(await _accountRepository.Login(loginViewModel.UserName, loginViewModel.Password));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}