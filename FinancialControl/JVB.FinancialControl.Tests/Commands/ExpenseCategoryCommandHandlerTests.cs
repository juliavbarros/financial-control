using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.ExpenseCategories;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class ExpenseCategoryCommandHandlerTests
    {
        private readonly Mock<IExpenseCategoryRepository> _mockUow;
        private readonly ExpenseCategoryCommandHandler _handler;

        public ExpenseCategoryCommandHandlerTests()
        {
            _mockUow = MockExpenseCategoryRepository.GetExpenseCategoryRepository();
            _handler =  new ExpenseCategoryCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_ExpenseCategory_Add()
        {
            var message = new RegisterNewExpenseCategoryCommand("Pacote TV");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_ExpenseCategory_Add()
        {
            var message = new RegisterNewExpenseCategoryCommand("P");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Valid_ExpenseCategory_Update()
        {
            var message = new UpdateExpenseCategoryCommand(1, "Arrendamento Updated");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.Name.ShouldBeSameAs(message.Name);

            entity.Id.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_ExpenseCategory_Update()
        {
            var message = new UpdateExpenseCategoryCommand(1, "A");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            entity.Name.ShouldNotBeSameAs(message.Name);
        }

        [Fact]
        public async Task Valid_ExpenseCategory_Remove()
        {
            var message = new RemoveExpenseCategoryCommand(1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task InValid_ExpenseCategory_Remove()
        {
            var message = new RemoveExpenseCategoryCommand(5);

            var result = await _handler.Handle(message, CancellationToken.None);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();
        }
    }
}