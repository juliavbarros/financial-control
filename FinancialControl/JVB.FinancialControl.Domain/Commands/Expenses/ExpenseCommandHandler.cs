using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Expenses
{
    public class ExpenseCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewExpenseCommand, ValidationResult>,
        IRequestHandler<UpdateExpenseCommand, ValidationResult>,
        IRequestHandler<RemoveExpenseCommand, ValidationResult>
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewExpenseCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expense = new Expense(0, message.Name, message.Description, message.Value, message.CurrentInstallment, message.Date, message.ExpenseCategoryId, message.UserId);

            _expenseRepository.Add(expense);

            return await Commit(_expenseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateExpenseCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expense = new Expense(message.Id, message.Name, message.Description, message.Value, message.CurrentInstallment, message.Date, message.ExpenseCategoryId, message.UserId);
      
            _expenseRepository.Update(expense);

            return await Commit(_expenseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveExpenseCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expense = await _expenseRepository.GetById(message.Id);

            if (expense is null)
            {
                AddError("The expense doesn't exists.");
                return ValidationResult;
            }

            _expenseRepository.Remove(expense);

            return await Commit(_expenseRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _expenseRepository.Dispose();
        }
    }
}