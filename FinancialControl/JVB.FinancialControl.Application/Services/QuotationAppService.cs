using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Quotations;

namespace JVB.FinancialControl.Application.Services
{
    public class QuotationAppService : IQuotationAppService
    {
        private readonly IMapper _mapper;
        private readonly IQuotationRepository _quotationRepository;
        private readonly IMediatorHandler _mediator;

        public QuotationAppService(IMapper mapper,
                                  IQuotationRepository quotationRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _quotationRepository = quotationRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<QuotationViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<QuotationViewModel>>(await _quotationRepository.GetAll());
        }

        public async Task<QuotationViewModel> GetById(int id)
        {
            return _mapper.Map<QuotationViewModel>(await _quotationRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(QuotationViewModel quotationViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewQuotationCommand>(quotationViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}