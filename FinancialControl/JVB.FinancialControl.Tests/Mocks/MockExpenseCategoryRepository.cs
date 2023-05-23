using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockExpenseCategoryRepository
    {
        public static Mock<IExpenseCategoryRepository> GetExpenseCategoryRepository()
        {
            var mock = new Mock<IExpenseCategoryRepository>();

            var expenseCategoryList = new List<ExpenseCategory>
            {
                new ExpenseCategory
                {
                    Id = 1,
                    Name = "Arrendamento"
                },
                new ExpenseCategory
                {
                     Id = 2,
                    Name = "Gasolina"
                },
                new ExpenseCategory
                {
                    Id = 3,
                    Name = "Mercado"
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => expenseCategoryList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => expenseCategoryList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetByName(It.IsAny<string>()))
                .ReturnsAsync((string name) => expenseCategoryList.FirstOrDefault(o => o.Name == name));

            mock.Setup(m => m.Add(It.IsAny<ExpenseCategory>())).Callback((ExpenseCategory expenseCategory) => { expenseCategoryList.Add(expenseCategory); });

            mock.Setup(m => m.Update(It.IsAny<ExpenseCategory>()))
                .Callback((ExpenseCategory expenseCategory) =>
                {
                    var existingExpenseCategory = expenseCategoryList.FirstOrDefault(o => o.Id == expenseCategory.Id);
                    if (existingExpenseCategory != null)
                    {
                        // Update the properties of existingExpenseCategory with the new values
                        existingExpenseCategory.Name = expenseCategory.Name;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<ExpenseCategory>())).Callback((ExpenseCategory expenseCategory) => { expenseCategoryList.RemoveAll(o => o.Id == expenseCategory.Id); });

            return mock;
        }
    }
}