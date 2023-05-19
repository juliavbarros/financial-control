using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.GoalCategories;

namespace JVB.FinancialControl.Application.Services
{
    public class GoalCategoryAppService : IGoalCategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly IGoalCategoryRepository _goalCategoryRepository;
        private readonly IMediatorHandler _mediator;

        public GoalCategoryAppService(IMapper mapper,
                                  IGoalCategoryRepository goalCategoryRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _goalCategoryRepository = goalCategoryRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GoalCategoryViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<GoalCategoryViewModel>>(await _goalCategoryRepository.GetAll());
        }

        public async Task<GoalCategoryViewModel> GetById(int id)
        {
            return _mapper.Map<GoalCategoryViewModel>(await _goalCategoryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(GoalCategoryViewModel goalCategoryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewGoalCategoryCommand>(goalCategoryViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(GoalCategoryViewModel goalCategoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateGoalCategoryCommand>(goalCategoryViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveGoalCategoryCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}