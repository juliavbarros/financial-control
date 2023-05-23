using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class ExpenseCategoryQueriesTests
    {
        private readonly Mock<IExpenseCategoryRepository> _mockUow;

        public ExpenseCategoryQueriesTests()
        {
            _mockUow = MockExpenseCategoryRepository.GetExpenseCategoryRepository();
        }

        [Fact]
        public async Task ExpenseCategory_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task ExpenseCategory_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task ExpenseCategory_GetByName()
        {
            var allObjects = await _mockUow.Object.GetByName("Gasolina");

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(2);
        }
    }
}