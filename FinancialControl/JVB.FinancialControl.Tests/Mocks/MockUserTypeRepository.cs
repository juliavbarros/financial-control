using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockUserTypeRepository
    {
        public static Mock<IUserTypeRepository> GetUserTypeRepository()
        {
            var mock = new Mock<IUserTypeRepository>();

            var userTypeList = new List<UserType>
            {
                new UserType
                {
                    Id = 1,
                    Name = "Administrador"
                },
                new UserType
                {
                    Id = 2,
                    Name = "Comum",
                },
                new UserType
                {
                    Id = 3,
                    Name = "Contador",
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => userTypeList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => userTypeList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetByName(It.IsAny<string>()))
                .ReturnsAsync((string name) => userTypeList.FirstOrDefault(o => o.Name == name));

            mock.Setup(m => m.Add(It.IsAny<UserType>())).Callback((UserType userType) => { userTypeList.Add(userType); });

            mock.Setup(m => m.Update(It.IsAny<UserType>()))
                .Callback((UserType userType) =>
                {
                    var existingUserType = userTypeList.FirstOrDefault(o => o.Id == userType.Id);
                    if (existingUserType != null)
                    {
                        // Update the properties of existingUserType with the new values
                        existingUserType.Name = userType.Name;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<UserType>())).Callback((UserType userType) => { userTypeList.RemoveAll(o => o.Id == userType.Id); });

            return mock;
        }
    }
}