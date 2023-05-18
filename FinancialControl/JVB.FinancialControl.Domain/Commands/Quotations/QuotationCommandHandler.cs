using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Quotations
{
    public class QuotationCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewQuotationCommand, ValidationResult>
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationCommandHandler(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewQuotationCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var quotation = new Quotation(0, message.InitialValue, message.ConvertedValue, message.QuotationDate, message.Rate, message.FromCurrencyId, message.ToCurrencyId, message.UserId);

            _quotationRepository.Add(quotation);

            return await Commit(_quotationRepository.UnitOfWork);
        }
        public void Dispose()
        {
            _quotationRepository.Dispose();
        }
    }
}