namespace JVB.FinancialControl.Domain.Commands.Taxes.Validations
{
    public class RemoveTaxCommandValidation : TaxValidation<RemoveTaxCommand>
    {
        public RemoveTaxCommandValidation()
        {
            ValidateId();
        }
    }
}