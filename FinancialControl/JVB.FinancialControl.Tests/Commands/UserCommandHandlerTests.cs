using FluentValidation.Results;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.Users;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class UserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUow;
        private readonly UserCommandHandler _handler;

        public UserCommandHandlerTests()
        {
            _mockUow = MockUserRepository.GetUserRepository();
            _handler =  new UserCommandHandler(_mockUow.Object);
        }

        [Fact]
        public async Task Valid_User_Add()
        {
            var message = new RegisterNewUserCommand("username4", "password4", "email4@gmail.com", "firstname4", "lastname4", DateTime.Now.AddYears(-20), 4, 4, 4);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allObjects = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            allObjects.Count().ShouldBe(4);
        }

        [Fact]
        public async Task InValid_User_Add()
        {
            var message = new RegisterNewUserCommand("username4", "password4", "email4@gmail.com", "firstname4", "lastname4", DateTime.Now.AddYears(-20), 4, 4, 0);

            var result = await _handler.Handle(message, CancellationToken.None);

            var allEntity = await _mockUow.Object.GetAll();

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            allEntity.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Valid_User_Update()
        {
            var message = new UpdateUserCommand(1, "username1Updated", "password1", "email1@gmail.com", "firstname1", "lastname1", DateTime.Now.AddYears(-20), 1, 1, 1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.Username.ShouldBeSameAs(message.Username);

            entity.Id.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_User_Update()
        {
            var message = new UpdateUserCommand(1, "username1Updated", "password1", "email1@gmail.com", "firstname1", "lastname1", DateTime.Now.AddYears(-20), 1, 1, 0);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();

            entity.Username.ShouldNotBeSameAs(message.Username);
        }

        [Fact]
        public async Task Valid_User_Remove()
        {
            var message = new RemoveUserCommand(1);

            var result = await _handler.Handle(message, CancellationToken.None);

            var entity = await _mockUow.Object.GetById(message.Id);

            result.ShouldBeOfType<ValidationResult>();

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task InValid_User_Remove()
        {
            var message = new RemoveUserCommand(5);

            var result = await _handler.Handle(message, CancellationToken.None);

            result.ShouldBeOfType<ValidationResult>();

            result.IsValid.ShouldBeFalse();
        }
    }
}