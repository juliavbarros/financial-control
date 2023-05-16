namespace JVB.FinancialControl.Domain.Commands.Currencies.Validations
{
    public class UpdateCurrencyCommandValidation : CurrencyValidation<UpdateCurrencyCommand>
    {
        public UpdateCurrencyCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateCode();
            ValidateSymbol();
        }
    }
}