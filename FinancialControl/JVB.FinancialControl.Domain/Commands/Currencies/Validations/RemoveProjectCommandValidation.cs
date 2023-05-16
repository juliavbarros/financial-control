namespace JVB.FinancialControl.Domain.Commands.Currencies.Validations
{
    public class RemoveCurrencyCommandValidation : CurrencyValidation<RemoveCurrencyCommand>
    {
        public RemoveCurrencyCommandValidation()
        {
            ValidateId();
        }
    }
}