using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Taxes
{
    public class TaxCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewTaxCommand, ValidationResult>,
        IRequestHandler<UpdateTaxCommand, ValidationResult>,
        IRequestHandler<RemoveTaxCommand, ValidationResult>
    {
        private readonly ITaxRepository _taxRepository;

        public TaxCommandHandler(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewTaxCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var tax = new Tax(0, message.Name, message.Description);

            if (await _taxRepository.GetByName(tax.Name) != null)
            {
                AddError("The tax name has already been taken.");
                return ValidationResult;
            }

            _taxRepository.Add(tax);

            return await Commit(_taxRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateTaxCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var tax = new Tax(message.Id, message.Name, message.Description);

            var existingTax = await _taxRepository.GetByName(tax.Name);

            if (existingTax != null && existingTax.Id != tax.Id)
            {
                if (!existingTax.Equals(tax))
                {
                    AddError("The tax e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _taxRepository.Update(tax);

            return await Commit(_taxRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveTaxCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var tax = await _taxRepository.GetById(message.Id);

            if (tax is null)
            {
                AddError("The tax doesn't exists.");
                return ValidationResult;
            }

            _taxRepository.Remove(tax);

            return await Commit(_taxRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _taxRepository.Dispose();
        }
    }
}