using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using Moq;

namespace JVB.FinancialControl.Tests.Mocks
{
    public static class MockQuotationRepository
    {
        public static Mock<IQuotationRepository> GetQuotationRepository()
        {
            var mock = new Mock<IQuotationRepository>();

            var quotationList = new List<Quotation>
            {
                new Quotation
                {
                   Id = 1,
                   InitialValue = 1,
                   ConvertedValue = 1,
                   QuotationDate = DateTime.Now,
                   Rate = 1,
                   FromCurrencyId = 1,
                   ToCurrencyId = 1,
                   UserId = 1,
                },
                new Quotation
                {
                   Id = 2,
                   InitialValue = 2,
                   ConvertedValue = 2,
                   QuotationDate = DateTime.Now,
                   Rate = 2,
                   FromCurrencyId = 2,
                   ToCurrencyId = 2,
                   UserId = 2,
                },
                new Quotation
                {
                   Id = 3,
                   InitialValue = 3,
                   ConvertedValue = 3,
                   QuotationDate = DateTime.Now,
                   Rate = 3,
                   FromCurrencyId = 3,
                   ToCurrencyId = 3,
                   UserId = 3,
                }
            };

            mock.Setup(m => m.GetAll()).ReturnsAsync(() => quotationList);

            mock.Setup(m => m.UnitOfWork.Commit()).ReturnsAsync(() => true);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => quotationList.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.Add(It.IsAny<Quotation>())).Callback((Quotation quotation) => { quotationList.Add(quotation); });

            mock.Setup(m => m.Update(It.IsAny<Quotation>()))
                .Callback((Quotation quotation) =>
                {
                    var existingQuotation = quotationList.FirstOrDefault(o => o.Id == quotation.Id);
                    if (existingQuotation != null)
                    {
                        // Update the properties of existingQuotation with the new values
                        existingQuotation.InitialValue = quotation.InitialValue;
                        existingQuotation.ConvertedValue = quotation.ConvertedValue;
                    }
                });

            mock.Setup(m => m.Remove(It.IsAny<Quotation>())).Callback((Quotation quotation) => { quotationList.RemoveAll(o => o.Id == quotation.Id); });

            return mock;
        }
    }
}