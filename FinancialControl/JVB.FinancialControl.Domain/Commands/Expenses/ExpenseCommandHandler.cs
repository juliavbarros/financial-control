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

            //if (await _expenseRepository.GetByCategory(expense.Name) != null)
            //{
            //    AddError("The expense name has already been taken.");
            //    return ValidationResult;
            //}

            _expenseRepository.Add(expense);

            return await Commit(_expenseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateExpenseCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expense = new Expense(message.Id, message.Name, message.Description, message.Value, message.CurrentInstallment, message.Date, message.ExpenseCategoryId, message.UserId);

            //var existingExpense = await _expenseRepository.GetByName(expense.Name);

            //if (existingExpense != null && existingExpense.Id != expense.Id)
            //{
            //    if (!existingExpense.Equals(expense))
            //    {
            //        AddError("The expense e-mail has already been taken.");
            //        return ValidationResult;
            //    }
            //}

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