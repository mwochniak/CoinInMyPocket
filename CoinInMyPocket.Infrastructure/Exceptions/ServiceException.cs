using CoinInMyPocket.Core.Abstractions;
using CoinInMyPocket.Core.Domain;

namespace CoinInMyPocket.Infrastructure.Exceptions
{
    public class ServiceException : CoinInMyPocketException
    {
        public ServiceException(ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "") : base(errorType, errorCode, message)
        {
        }
    }
}
