using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Customers;

namespace JVB.FinancialControl.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}