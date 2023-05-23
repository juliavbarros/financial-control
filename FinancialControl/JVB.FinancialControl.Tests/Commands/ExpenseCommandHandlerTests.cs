using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Expenses;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class ExpenseCommandHandlerTests
    {
        private readonly Mock<IExpenseRepository> _mockUow;
        private readonly ExpenseCommandHandler _handler;

        public ExpenseCommandHandlerTests()
        {
            _mockUow = MockExpenseRepository.GetExpenseRepository();
            _handler =  new ExpenseCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_Expense_Add()
        {
            var message = new RegisterNewExpenseCommand("Expense4", "Description4", 4, 4, DateTime.Now, 4, 4);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Expense_Add()
        {
            var message = new RegisterNewExpenseCommand("Expense4", "Description4", 4, 4, DateTime.Now, 4, 0);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Valid_Expense_Update()
        {
            var message = new UpdateExpenseCommand(1, "Expense1Updated", "Description1", 1, 1, DateTime.Now, 1, 1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.Name.ShouldBeSameAs(message.Name);

            entity.Id.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_Expense_Update()
        {
            var message = new UpdateExpenseCommand(1, "Expense1Updated", "Description1", 1, 1, DateTime.Now, 0, 1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            entity.Name.ShouldNotBeSameAs(message.Name);
        }

        [Fact]
        public async Task Valid_Expense_Remove()
        {
            var message = new RemoveExpenseCommand(1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task InValid_Expense_Remove()
        {
            var message = new RemoveExpenseCommand(5);

            var result = await _handler.Handle(message, CancellationToken.None);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();
        }
    }
}