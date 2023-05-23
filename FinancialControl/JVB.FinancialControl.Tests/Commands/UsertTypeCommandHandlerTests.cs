using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.UserTypes;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class UserTypeCommandHandlerTests
    {
        private readonly Mock<IUserTypeRepository> _mockUow;
        private readonly UserTypeCommandHandler _handler;

        public UserTypeCommandHandlerTests()
        {
            _mockUow = MockUserTypeRepository.GetUserTypeRepository();
            _handler =  new UserTypeCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_UserType_Add()
        {
            var message = new RegisterNewUserTypeCommand("Professor");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_UserType_Add()
        {
            var message = new RegisterNewUserTypeCommand("P");

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Valid_UserType_Update()
        {
            var message = new UpdateUserTypeCommand(1, "Administrador Atualizado");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.Name.ShouldBeSameAs(message.Name);

            entity.Id.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_UserType_Update()
        {
            var message = new UpdateUserTypeCommand(1, "A");

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            entity.Name.ShouldNotBeSameAs(message.Name);
        }

        [Fact]
        public async Task Valid_UserType_Remove()
        {
            var message = new RemoveUserTypeCommand(1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task InValid_UserType_Remove()
        {
            var message = new RemoveUserTypeCommand(5);

            var result = await _handler.Handle(message, CancellationToken.None);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();
        }
    }
}