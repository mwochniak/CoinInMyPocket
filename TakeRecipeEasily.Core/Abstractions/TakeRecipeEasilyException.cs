using TakeRecipeEasily.Core.Domain;
using System;

namespace TakeRecipeEasily.Core.Abstractions
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
