using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Projects;

namespace JVB.FinancialControl.Application.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IMediatorHandler _mediator;

        public ProjectAppService(IMapper mapper,
                                  IProjectRepository projectRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectRepository.GetAll());
        }

        public async Task<ProjectViewModel> GetById(int id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProjectViewModel projectViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProjectCommand>(projectViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProjectViewModel projectViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(projectViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveProjectCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}