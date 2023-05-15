using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Projects
{
    public class ProjectCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProjectCommand, ValidationResult>,
        IRequestHandler<UpdateProjectCommand, ValidationResult>,
        IRequestHandler<RemoveProjectCommand, ValidationResult>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = new Project(0, message.Name, message.Description);

            if (await _projectRepository.GetByName(project.Name) != null)
            {
                AddError("The project name has already been taken.");
                return ValidationResult;
            }

            _projectRepository.Add(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = new Project(message.Id, message.Name, message.Description);

            var existingProject = await _projectRepository.GetByName(project.Name);

            if (existingProject != null && existingProject.Id != project.Id)
            {
                if (!existingProject.Equals(project))
                {
                    AddError("The project e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _projectRepository.Update(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = await _projectRepository.GetById(message.Id);

            if (project is null)
            {
                AddError("The project doesn't exists.");
                return ValidationResult;
            }

            _projectRepository.Remove(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _projectRepository.Dispose();
        }
    }
}