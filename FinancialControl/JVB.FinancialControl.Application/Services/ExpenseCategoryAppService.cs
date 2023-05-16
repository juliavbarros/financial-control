using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.ExpenseCategories;

namespace JVB.FinancialControl.Application.Services
{
    public class ExpenseCategoryAppService : IExpenseCategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMediatorHandler _mediator;

        public ExpenseCategoryAppService(IMapper mapper,
                                  IExpenseCategoryRepository expenseCategoryRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _expenseCategoryRepository = expenseCategoryRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ExpenseCategoryViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ExpenseCategoryViewModel>>(await _expenseCategoryRepository.GetAll());
        }

        public async Task<ExpenseCategoryViewModel> GetById(int id)
        {
            return _mapper.Map<ExpenseCategoryViewModel>(await _expenseCategoryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ExpenseCategoryViewModel expenseCategoryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewExpenseCategoryCommand>(expenseCategoryViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ExpenseCategoryViewModel expenseCategoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateExpenseCategoryCommand>(expenseCategoryViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveExpenseCategoryCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}