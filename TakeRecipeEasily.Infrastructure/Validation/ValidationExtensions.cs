using System;
using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Exceptions;

namespace TakeRecipeEasily.Infrastructure.Validation
{
    public static class ValidationExtensions
    {
        public static void ThrowIfTrue(this bool condition, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
        {
            if (condition)
            {
                throw new ServiceException(errorType, errorCode, message);
            }
        }

        public static T ThrowIfTrue<T>(this T item, Predicate<T> predicate, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
        {
            ThrowIfTrue(predicate(item), errorType, errorCode, message);
            return item;
        }

        public static void ThrowIfFalse(this bool condition, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            => ThrowIfTrue(!condition, errorType, errorCode, message);

        public static T ThrowIfFalse<T>(this T item, Predicate<T> predicate, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
        {
            ThrowIfFalse(predicate(item), errorType, errorCode, message);
            return item;
        }

        public static T ThrowIfNull<T>(this T item, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
        {
            ThrowIfTrue(item == null, errorType, errorCode, message);
            return item;
        }
    }
}
