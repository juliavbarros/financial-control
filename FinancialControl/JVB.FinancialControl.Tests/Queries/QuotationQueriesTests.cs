using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class QuotationQueriesTests
    {
        private readonly Mock<IQuotationRepository> _mockUow;

        public QuotationQueriesTests()
        {
            _mockUow = MockQuotationRepository.GetQuotationRepository();
        }

        [Fact]
        public async Task Quotation_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Quotation_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }
    }
}