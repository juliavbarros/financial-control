using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockCurrencyRepository
    {
        public static Mock<ICurrencyRepository> GetCurrencyRepository()
        {
            var mock = new Mock<ICurrencyRepository>();

            var currencyList = new List<Currency>
            {
                new Currency
                {
                    Id = 1,
                    Name = "Dolar",
                    Code = "USD",
                    Symbol = "USD"
                },
                new Currency
                {
                     Id = 2,
                    Name = "Euro",
                    Code = "EUR",
                    Symbol = "EUR"
                },
                new Currency
                {
                    Id = 3,
                    Name = "Real",
                    Code = "RS",
                    Symbol = "RS"
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => currencyList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => currencyList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetByCode(It.IsAny<string>()))
                .ReturnsAsync((string code) => currencyList.FirstOrDefault(o => o.Code == code));

            mock.Setup(m => m.Add(It.IsAny<Currency>())).Callback((Currency currency) => { currencyList.Add(currency); });

            mock.Setup(m => m.Update(It.IsAny<Currency>()))
                .Callback((Currency currency) =>
                {
                    var existingCurrency = currencyList.FirstOrDefault(o => o.Id == currency.Id);
                    if (existingCurrency != null)
                    {
                        // Update the properties of existingCurrency with the new values
                        existingCurrency.Name = currency.Name;
                        existingCurrency.Code = currency.Code;
                        existingCurrency.Symbol = currency.Symbol;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<Currency>())).Callback((Currency currency) => { currencyList.RemoveAll(o => o.Id == currency.Id); });

            return mock;
        }
    }
}