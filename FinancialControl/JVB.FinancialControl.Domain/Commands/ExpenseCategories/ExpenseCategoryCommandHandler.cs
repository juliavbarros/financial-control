using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.ExpenseCategories
{
    public class ExpenseCategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewExpenseCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateExpenseCategoryCommand, ValidationResult>,
        IRequestHandler<RemoveExpenseCategoryCommand, ValidationResult>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public ExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewExpenseCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expenseCategory = new ExpenseCategory(0, message.Name);

            if (await _expenseCategoryRepository.GetByName(expenseCategory.Name) != null)
            {
                AddError("The expenseCategory name has already been taken.");
                return ValidationResult;
            }

            _expenseCategoryRepository.Add(expenseCategory);

            return await Commit(_expenseCategoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateExpenseCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expenseCategory = new ExpenseCategory(message.Id, message.Name);

            var existingExpenseCategory = await _expenseCategoryRepository.GetByName(expenseCategory.Name);

            if (existingExpenseCategory != null && existingExpenseCategory.Id != expenseCategory.Id)
            {
                if (!existingExpenseCategory.Equals(expenseCategory))
                {
                    AddError("The expenseCategory e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _expenseCategoryRepository.Update(expenseCategory);

            return await Commit(_expenseCategoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveExpenseCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var expenseCategory = await _expenseCategoryRepository.GetById(message.Id);

            if (expenseCategory is null)
            {
                AddError("The expenseCategory doesn't exists.");
                return ValidationResult;
            }

            _expenseCategoryRepository.Remove(expenseCategory);

            return await Commit(_expenseCategoryRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _expenseCategoryRepository.Dispose();
        }
    }
}