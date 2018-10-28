using Microsoft.AspNetCore.Builder;

namespace CoinInMyPocket.Infrastructure.Exceptions
{
    public static class ExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCoinInMyPocketExceptions(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
