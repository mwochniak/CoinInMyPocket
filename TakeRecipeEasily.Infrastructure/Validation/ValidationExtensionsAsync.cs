using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Exceptions;

namespace TakeRecipeEasily.Infrastructure.Validation
{
    public static class ValidationExtensionsAsync
    {
        public static async Task ThrowIfTrueAsync(this Task<bool> task, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            => ValidationExtensions.ThrowIfTrue(await task, errorType, errorCode, message);

        public static async Task<T> ThrowIfTrueAsync<T>(this Task<T> task, Predicate<T> predicate, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            => ValidationExtensions.ThrowIfTrue(await task, predicate, errorType, errorCode, message);

        public static async Task ThrowIfFalseAsync(this Task<bool> task, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            => ValidationExtensions.ThrowIfFalse(await task, errorType, errorCode, message);

        public static async Task<T> ThrowIfFalseAsync<T>(this Task<T> task, Predicate<T> predicate, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            => ValidationExtensions.ThrowIfFalse(await task, predicate, errorType, errorCode, message);

        public static async Task<TResult> ThrowIfNullAsync<TResult>(this Task<TResult> task, ErrorType errorType = ErrorType.Unknown, string errorCode = "", string message = "")
            where TResult : class
            => ValidationExtensions.ThrowIfNull(await task, errorType, errorCode, message);
    }
}
