using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var mock = new Mock<IUserRepository>();

            var userList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "password1",
                    Email = "Email1@gmail.com",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    BirthDate = DateTime.Now,
                    GrossSalary = 1,
                    NetSalary = 1,
                    UserTypeId = 1
                },
                new User
                {
                    Id = 2,
                    Username = "Username2",
                    Password = "password2",
                    Email = "Email2@gmail.com",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    BirthDate = DateTime.Now,
                    GrossSalary = 2,
                    NetSalary = 2,
                    UserTypeId = 2
                },
                new User
                {
                    Id = 3,
                    Username = "Username3",
                    Password = "password3",
                    Email = "Email3@gmail.com",
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    BirthDate = DateTime.Now,
                    GrossSalary = 3,
                    NetSalary = 3,
                    UserTypeId = 3
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => userList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => userList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetByUserName(It.IsAny<string>()))
                .ReturnsAsync((string userName) => userList.FirstOrDefault(o => o.Username == userName));

            mock.Setup(m => m.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync((string email) => userList.FirstOrDefault(o => o.Email == email));

            mock.Setup(m => m.Add(It.IsAny<User>())).Callback((User user) => { userList.Add(user); });

            mock.Setup(m => m.Update(It.IsAny<User>()))
                .Callback((User user) =>
                {
                    var existingUser = userList.FirstOrDefault(o => o.Id == user.Id);
                    if (existingUser != null)
                    {
                        // Update the properties of existingUser with the new values
                        existingUser.Username = user.Username;
                        existingUser.Password = user.Password;
                        existingUser.Email = user.Email;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<User>())).Callback((User user) => { userList.RemoveAll(o => o.Id == user.Id); });

            return mock;
        }
    }
}