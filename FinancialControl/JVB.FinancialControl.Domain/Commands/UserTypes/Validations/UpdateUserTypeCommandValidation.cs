namespace JVB.FinancialControl.Domain.Commands.UserTypes.Validations
{
    public class UpdateUserTypeCommandValidation : UserTypeValidation<UpdateUserTypeCommand>
    {
        public UpdateUserTypeCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}