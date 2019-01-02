using TakeRecipeEasily.Core.Abstractions;

namespace TakeRecipeEasily.Core.Domain
{
    public class DomainException : TakeRecipeEasilyException
    {
        public DomainException(
            ErrorType errorType = ErrorType.Unknown,
            string errorCode = "",
            string message = "") : base(errorType, errorCode, message)
        {
        }
    }
}
