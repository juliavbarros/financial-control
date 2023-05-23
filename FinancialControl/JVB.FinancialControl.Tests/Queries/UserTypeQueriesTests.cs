using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace JVB.FinancialControl.Tests.Commands
{
    public class UserTypeQueriesTests
    {
        private readonly Mock<IUserTypeRepository> _mockUow;

        public UserTypeQueriesTests()
        {
            _mockUow = MockUserTypeRepository.GetUserTypeRepository();
        }

        [Fact]
        public async Task UserType_GetAll()
        {
            var allObjects = await _mockUow.Object.GetAll();

            allObjects.Count().ShouldBe(3);
        }

        [Fact]
        public async Task UserType_GetById()
        {
            var allObjects = await _mockUow.Object.GetById(1);

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }

        [Fact]
        public async Task UserType_GetByCode()
        {
            var allObjects = await _mockUow.Object.GetByName("Administrador");

            allObjects.ShouldNotBeNull();
            allObjects.Id.ShouldBe(1);
        }
    }
}