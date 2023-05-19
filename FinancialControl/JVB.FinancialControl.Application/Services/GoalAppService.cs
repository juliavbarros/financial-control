using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Goals;

namespace JVB.FinancialControl.Application.Services
{
    public class GoalAppService : IGoalAppService
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;
        private readonly IMediatorHandler _mediator;

        public GoalAppService(IMapper mapper,
                                  IGoalRepository goalRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GoalViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<GoalViewModel>>(await _goalRepository.GetAll());
        }

        public async Task<GoalViewModel> GetById(int id)
        {
            return _mapper.Map<GoalViewModel>(await _goalRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(GoalViewModel goalViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewGoalCommand>(goalViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(GoalViewModel goalViewModel)
        {
            var updateCommand = _mapper.Map<UpdateGoalCommand>(goalViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveGoalCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}