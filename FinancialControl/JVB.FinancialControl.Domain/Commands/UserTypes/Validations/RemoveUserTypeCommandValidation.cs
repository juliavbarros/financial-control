using JVB.FinancialControl.Domain.Commands.UserTypes;

namespace JVB.FinancialControl.Domain.Commands.UserTypes.Validations
{
    public class RemoveUserTypeCommandValidation : UserTypeValidation<RemoveUserTypeCommand>
    {
        public RemoveUserTypeCommandValidation()
        {
            ValidateId();
        }
    }
}