using CoinInMyPocket.Core.Domain;
using System;

namespace CoinInMyPocket.Core.Abstractions
{
    public abstract class CoinInMyPocketException : Exception
    {
        public ErrorType ErrorType { get; }
        public string ErrorCode { get; }

        protected CoinInMyPocketException(ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            : base(message)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
        }
    }
}
