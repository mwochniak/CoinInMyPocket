using Microsoft.AspNetCore.Builder;

namespace TakeRecipeEasily.Infrastructure.Exceptions
{
    public static class ExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseTakeRecipeEasilyExceptions(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
