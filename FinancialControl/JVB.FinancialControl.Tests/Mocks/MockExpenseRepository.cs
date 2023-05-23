using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockExpenseRepository
    {
        public static Mock<IExpenseRepository> GetExpenseRepository()
        {
            var mock = new Mock<IExpenseRepository>();

            var expenseList = new List<Expense>
            {
                new Expense
                {
                    Id = 1,
                    Name = "Name2",
                    Description = "Description1",
                    Value = 1,
                    CurrentInstallment = 1,
                    Date = DateTime.Now,
                    ExpenseCategoryId = 1,
                    UserId = 1
                },
                new Expense
                {
                    Id = 2,
                    Name = "Name2",
                    Description = "Description2",
                    Value = 2,
                    CurrentInstallment = 2,
                    Date = DateTime.Now,
                    ExpenseCategoryId = 2,
                    UserId = 2
                },
                new Expense
                {
                   Id = 3,
                    Name = "Name3",
                    Description = "Description3",
                    Value = 3,
                    CurrentInstallment = 3,
                    Date = DateTime.Now,
                    ExpenseCategoryId = 3,
                    UserId = 2
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => expenseList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => expenseList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetByUserId(It.IsAny<int>()))
                .ReturnsAsync((int userId) => expenseList.Where(o => o.UserId == userId));

            mock.Setup(m => m.Add(It.IsAny<Expense>())).Callback((Expense expense) => { expenseList.Add(expense); });

            mock.Setup(m => m.Update(It.IsAny<Expense>()))
                .Callback((Expense expense) =>
                {
                    var existingExpense = expenseList.FirstOrDefault(o => o.Id == expense.Id);
                    if (existingExpense != null)
                    {
                        // Update the properties of existingExpense with the new values
                        existingExpense.Name = expense.Name;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<Expense>())).Callback((Expense expense) => { expenseList.RemoveAll(o => o.Id == expense.Id); });

            return mock;
        }
    }
}