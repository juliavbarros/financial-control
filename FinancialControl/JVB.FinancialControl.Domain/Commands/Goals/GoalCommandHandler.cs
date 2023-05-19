using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Goals
{
    public class GoalCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewGoalCommand, ValidationResult>,
        IRequestHandler<UpdateGoalCommand, ValidationResult>,
        IRequestHandler<RemoveGoalCommand, ValidationResult>
    {
        private readonly IGoalRepository _goalRepository;

        public GoalCommandHandler(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goal = new Goal(0, message.Name, message.Description, message.TotalValue, message.EntryValue, message.QuantityInstallment, message.MonthlyInstallmentValue, message.BeginDate, message.EndDate, message.GoalCategoryId, message.UserId);

            if (await _goalRepository.GetByName(goal.Name) != null)
            {
                AddError("The goal name has already been taken.");
                return ValidationResult;
            }

            _goalRepository.Add(goal);

            return await Commit(_goalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goal = new Goal(message.Id, message.Name, message.Description, message.TotalValue, message.EntryValue, message.QuantityInstallment, message.MonthlyInstallmentValue, message.BeginDate, message.EndDate, message.GoalCategoryId, message.UserId);

            var existingGoal = await _goalRepository.GetByName(goal.Name);

            if (existingGoal != null && existingGoal.Id != goal.Id)
            {
                if (!existingGoal.Equals(goal))
                {
                    AddError("The goal e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _goalRepository.Update(goal);

            return await Commit(_goalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var goal = await _goalRepository.GetById(message.Id);

            if (goal is null)
            {
                AddError("The goal doesn't exists.");
                return ValidationResult;
            }

            _goalRepository.Remove(goal);

            return await Commit(_goalRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _goalRepository.Dispose();
        }
    }
}