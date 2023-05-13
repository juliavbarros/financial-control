using FluentValidation.Results;

namespace JVB.FinancialControl.Common.Bus
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}