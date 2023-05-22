using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class CurrencyQueriesTests
    {
        private readonly Mock<ICurrencyRepository> _mockUow;

        public CurrencyQueriesTests()
        {
            _mockUow = MockCurrencyRepository.GetCurrencyRepository();
        }

        [Fact]
        public async Task Currency_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Currency_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task Currency_GetByCode()
        {
            var allObjects = await _mockUow.Object.GetByCode("EUR");

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(2);
        }
    }
}