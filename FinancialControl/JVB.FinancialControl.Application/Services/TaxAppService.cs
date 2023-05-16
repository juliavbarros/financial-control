using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Taxes;

namespace JVB.FinancialControl.Application.Services
{
    public class TaxAppService : ITaxAppService
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;
        private readonly IMediatorHandler _mediator;

        public TaxAppService(IMapper mapper,
                                  ITaxRepository taxRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TaxViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TaxViewModel>>(await _taxRepository.GetAll());
        }

        public async Task<TaxViewModel> GetById(int id)
        {
            return _mapper.Map<TaxViewModel>(await _taxRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(TaxViewModel taxViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTaxCommand>(taxViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(TaxViewModel taxViewModel)
        {
            var updateCommand = _mapper.Map<UpdateTaxCommand>(taxViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveTaxCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}