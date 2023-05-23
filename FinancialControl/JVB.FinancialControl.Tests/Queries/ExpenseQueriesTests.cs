using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class ExpenseQueriesTests
    {
        private readonly Mock<IExpenseRepository> _mockUow;

        public ExpenseQueriesTests()
        {
            _mockUow = MockExpenseRepository.GetExpenseRepository();
        }

        [Fact]
        public async Task Expense_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Expense_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task Expense_GetByCode()
        {
            var allObjects = await _mockUow.Object.GetByUserId(1);

            allObjects.ShouldNotBeNull();
        }
    }
}