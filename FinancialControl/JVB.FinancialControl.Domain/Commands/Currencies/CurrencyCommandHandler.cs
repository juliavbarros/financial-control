using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Currencies
{
    public class CurrencyCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCurrencyCommand, ValidationResult>,
        IRequestHandler<UpdateCurrencyCommand, ValidationResult>,
        IRequestHandler<RemoveCurrencyCommand, ValidationResult>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCurrencyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var currency = new Currency(0, message.Name,  message.Code, message.Symbol);

            if (await _currencyRepository.GetByCode(currency.Code) != null)
            {
                AddError("The currency name has already been taken.");
                return ValidationResult;
            }

            _currencyRepository.Add(currency);

            return await Commit(_currencyRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCurrencyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var currency = new Currency(message.Id, message.Name,message.Code, message.Symbol);

            var existingCurrency = await _currencyRepository.GetByCode(currency.Code);

            if (existingCurrency != null && existingCurrency.Id != currency.Id)
            {
                if (!existingCurrency.Equals(currency))
                {
                    AddError("The currency e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _currencyRepository.Update(currency);

            return await Commit(_currencyRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCurrencyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var currency = await _currencyRepository.GetById(message.Id);

            if (currency is null)
            {
                AddError("The currency doesn't exists.");
                return ValidationResult;
            }

            _currencyRepository.Remove(currency);

            return await Commit(_currencyRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _currencyRepository.Dispose();
        }
    }
}