﻿using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Currencies;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class CurrencyCommandHandlerTests
    {
        private readonly Mock<ICurrencyRepository> _mockUow;
        private readonly CurrencyCommandHandler _handler;

        public CurrencyCommandHandlerTests()
        {
            _mockUow = MockCurrencyRepository.GetCurrencyRepository();
            _handler =  new CurrencyCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_Currency_Add()
        {
            var message = new RegisterNewCurrencyCommand("Libra", "GBP", "l");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Currency_Add()
        {
            var message = new RegisterNewCurrencyCommand("Libra", "GBP3", "l");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Valid_Currency_Update()
        {
            var message = new UpdateCurrencyCommand(1, "Dolar Updated", "USD", "USD");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.Name.ShouldBeSameAs(message.Name);

            entity.Id.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_Currency_Update()
        {
            var message = new UpdateCurrencyCommand(1, "Dolar Updated", "USD3", "USD");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            entity.Name.ShouldNotBeSameAs(message.Name);
        }

        [Fact]
        public async Task Valid_Currency_Remove()
        {
            var message = new RemoveCurrencyCommand(1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task InValid_Currency_Remove()
        {
            var message = new RemoveCurrencyCommand(5);

            var result = await _handler.Handle(message, CancellationToken.None);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();
        }
    }
}