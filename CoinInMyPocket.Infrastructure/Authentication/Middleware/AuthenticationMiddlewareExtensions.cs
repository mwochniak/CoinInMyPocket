using Microsoft.AspNetCore.Builder;

namespace CoinInMyPocket.Infrastructure.Authentication.Middleware
{
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtAuthentication(this IApplicationBuilder builder)
            => builder.UseMiddleware<JwtAuthorizationMiddleware>();
    }
}
