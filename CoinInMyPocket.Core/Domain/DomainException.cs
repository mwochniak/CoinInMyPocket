using CoinInMyPocket.Core.Abstractions;

namespace CoinInMyPocket.Core.Domain
{
    public class DomainException : CoinInMyPocketException
    {
        public DomainException(ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "") : base(errorType, errorCode, message)
        {
        }
    }
}
