using TakeRecipeEasily.Core.Exceptions;

namespace TakeRecipeEasily.Infrastructure.Exceptions
{
    public class ServiceException : TakeRecipeEasilyException
    {
        public ServiceException(ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "") : base(errorType, errorCode, message)
        {
        }
    }
}
