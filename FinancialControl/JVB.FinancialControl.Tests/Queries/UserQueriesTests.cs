using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class UserQueriesTests
    {
        private readonly Mock<IUserRepository> _mockUow;

        public UserQueriesTests()
        {
            _mockUow = MockUserRepository.GetUserRepository();
        }

        [Fact]
        public async Task User_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task User_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task User_GetByUserName()
        {
            var allObjects = await _mockUow.Object.GetByUserName("Username1");

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task User_GetByEmail()
        {
            var allObjects = await _mockUow.Object.GetByEmail("Email1@gmail.com");

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }
    }
}