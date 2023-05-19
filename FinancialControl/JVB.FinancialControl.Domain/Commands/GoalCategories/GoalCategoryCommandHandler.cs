using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.GoalCategories
{
    public class GoalCategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewGoalCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateGoalCategoryCommand, ValidationResult>,
        IRequestHandler<RemoveGoalCategoryCommand, ValidationResult>
    {
        private readonly IGoalCategoryRepository _goalCategoryRepository;

        public GoalCategoryCommandHandler(IGoalCategoryRepository goalCategoryRepository)
        {
            _goalCategoryRepository = goalCategoryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewGoalCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goalCategory = new GoalCategory(0, message.Name, message.Description);

            if (await _goalCategoryRepository.GetByName(goalCategory.Name) != null)
            {
                AddError("The goalCategory name has already been taken.");
                return ValidationResult;
            }

            _goalCategoryRepository.Add(goalCategory);

            return await Commit(_goalCategoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateGoalCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goalCategory = new GoalCategory(message.Id, message.Name, message.Description);

            var existingGoalCategory = await _goalCategoryRepository.GetByName(goalCategory.Name);

            if (existingGoalCategory != null && existingGoalCategory.Id != goalCategory.Id)
            {
                if (!existingGoalCategory.Equals(goalCategory))
                {
                    AddError("The goalCategory e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _goalCategoryRepository.Update(goalCategory);

            return await Commit(_goalCategoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveGoalCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goalCategory = await _goalCategoryRepository.GetById(message.Id);

            if (goalCategory is null)
            {
                AddError("The goalCategory doesn't exists.");
                return ValidationResult;
            }

            _goalCategoryRepository.Remove(goalCategory);

            return await Commit(_goalCategoryRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _goalCategoryRepository.Dispose();
        }
    }
}