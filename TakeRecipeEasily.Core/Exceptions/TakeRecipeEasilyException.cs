using System;

namespace TakeRecipeEasily.Core.Exceptions
{
    public abstract class TakeRecipeEasilyException : Exception
    {
        public ErrorType ErrorType { get; }
        public string ErrorCode { get; }

        protected TakeRecipeEasilyException(ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            : base(message)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
        }
    }
}
