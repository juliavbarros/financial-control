using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Quotations;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class QuotationCommandHandlerTests
    {
        private readonly Mock<IQuotationRepository> _mockUow;
        private readonly QuotationCommandHandler _handler;

        public QuotationCommandHandlerTests()
        {
            _mockUow = MockQuotationRepository.GetQuotationRepository();
            _handler =  new QuotationCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_Quotation_Add()
        {
            var message = new RegisterNewQuotationCommand(4, 4, DateTime.Now, 4, 4, 4, 4);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Quotation_Add()
        {
            var message = new RegisterNewQuotationCommand(4, 4, DateTime.Now, 4, 4, 4, 0);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }
    }
}