using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Currencies;

namespace JVB.FinancialControl.Application.Services
{
    public class CurrencyAppService : ICurrencyAppService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMediatorHandler _mediator;

        public CurrencyAppService(IMapper mapper,
                                  ICurrencyRepository currencyRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CurrencyViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CurrencyViewModel>>(await _currencyRepository.GetAll());
        }

        public async Task<CurrencyViewModel> GetById(int id)
        {
            return _mapper.Map<CurrencyViewModel>(await _currencyRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CurrencyViewModel currencyViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCurrencyCommand>(currencyViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(CurrencyViewModel currencyViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCurrencyCommand>(currencyViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveCurrencyCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}