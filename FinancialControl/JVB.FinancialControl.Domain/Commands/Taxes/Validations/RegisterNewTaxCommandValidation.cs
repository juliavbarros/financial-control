using JVB.FinancialControl.Domain.Commands.Taxes;

namespace JVB.FinancialControl.Domain.Commands.Taxes.Validations
{
    public class RegisterNewTaxCommandValidation : TaxValidation<RegisterNewTaxCommand>
    {
        public RegisterNewTaxCommandValidation()
        {
            ValidateName();
            ValidateDescription();
        }
    }
}