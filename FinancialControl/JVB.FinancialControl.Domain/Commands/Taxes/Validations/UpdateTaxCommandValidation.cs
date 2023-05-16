namespace JVB.FinancialControl.Domain.Commands.Taxes.Validations
{
    public class UpdateTaxCommandValidation : TaxValidation<UpdateTaxCommand>
    {
        public UpdateTaxCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateId();
        }
    }
}